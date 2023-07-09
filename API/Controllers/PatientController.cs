using API.DataAccess.Repository.IRepository;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class PatientController : BaseApiController
    {
        private readonly IPatientRepository _patient;
        private readonly INcdRepository _ncdDetRepo;
        private readonly IAllergiesRepository _allergiesDetRepo;
        private readonly IRepository<Patient> _patientRepo;
        private readonly IRepository<NCD_Details> _ncdRepo;
        private readonly IRepository<Allergies_Details> _allergiesRepo;

        public PatientController(IRepository<Patient> patientRepo, IRepository<NCD_Details> ncdRepo, 
            IRepository<Allergies_Details> allergiesRepo, IPatientRepository patient, INcdRepository ncdDetRepo,
            IAllergiesRepository allergiesDetRepo)
        {
            _patientRepo = patientRepo;
            _ncdRepo = ncdRepo;
            _allergiesRepo = allergiesRepo;
            _patient = patient;
            _ncdDetRepo = ncdDetRepo;
            _allergiesDetRepo = allergiesDetRepo;
        }

        [HttpGet("GetAllPatientList")]
        public async Task<IEnumerable<Patient>> GetAllPatientList()
        {
            return await _patientRepo.GetAllAsync(includeProperties: "DiseaseInformation");
        }

        [HttpGet("GetPatientInformation")]
        public async Task<IActionResult> GetPatientInformation(Guid id)
        {
            if (id == Guid.Empty) return NotFound();
            return Ok(await _patientRepo.FirstOrDefaultAsync(x=>x.PatientId == id, includeProperties: "DiseaseInformation"));
        }

        [HttpPost("UpsertPatient")]
        public async Task<ActionResult<Patient>> UpsertPatient(Patient patient)
        {
            if (patient.PatientId != Guid.Empty)
            {
                //for update
                if (ModelState.IsValid)
                {
                    await _patient.UpdatePatient(patient);

                    if(patient.NCDs.Count > 0)
                    {
                        await _ncdDetRepo.RemoveAll(patient.PatientId);
                        var ncdsList = new List<NCD_Details>();
                        foreach (var item in patient.NCDs)
                        {
                            var ncd = new NCD_Details();
                            ncd.NCDID = item.NCDID;
                            ncd.PatientId = patient.PatientId;
                            ncdsList.Add(ncd);
                        }
                        await _ncdRepo.AddMultipleAsync(ncdsList);
                    }
                    else
                    {
                        await _ncdDetRepo.RemoveAll(patient.PatientId);
                    }

                    if(patient.Allergies.Count > 0)
                    {
                        await _allergiesDetRepo.RemoveAll(patient.PatientId);
                        var allergiestList = new List<Allergies_Details>();
                        foreach (var item in patient.Allergies)
                        {
                            var allergies = new Allergies_Details();
                            allergies.AllergiesID = item.AllergiesID;
                            allergies.PatientId = patient.PatientId;
                            allergiestList.Add(allergies);
                        }
                        await _allergiesRepo.AddMultipleAsync(allergiestList);
                    }

                    else
                    {
                        await _allergiesDetRepo.RemoveAll(patient.PatientId);
                    }
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //for create
                    await _patientRepo.AddAsync(patient);

                    if (patient.NCDs != null)
                    {
                        foreach (var item in patient.NCDs)
                        {
                            var ncdDetails = new NCD_Details();
                            ncdDetails.PatientId = patient.PatientId;
                            ncdDetails.NCDID = item.NCDID;
                            await _ncdRepo.AddAsync(ncdDetails);
                        }
                    }
                    if (patient.Allergies != null)
                    {
                        foreach (var item in patient.Allergies)
                        {
                            var allergiesDetails = new Allergies_Details();
                            allergiesDetails.PatientId = patient.PatientId;
                            allergiesDetails.AllergiesID = item.AllergiesID;
                            await _allergiesRepo.AddAsync(allergiesDetails);
                        }
                    }
                }
            }

            if (await _patientRepo.SaveAllAsync()) return patient;

            return BadRequest();
        }

        [HttpPost("DeletePatient")]
        public async Task<ActionResult> DeletePatient(Guid patientId)
        {
            if(patientId != Guid.Empty)
            {
                var patientInformation = await _patientRepo.FindAsync(patientId);
                await _patientRepo.Remove(patientInformation);

                await _ncdDetRepo.RemoveAll(patientId);
                await _allergiesDetRepo.RemoveAll(patientId);

                return Ok(await _patientRepo.SaveAllAsync());
            }
            return BadRequest();
        }
    }
}
