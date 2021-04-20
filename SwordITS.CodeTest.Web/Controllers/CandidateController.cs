using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwordITS.CodeTest.Model;
using SwordITS.CodeTest.Services;
using SwordITS.CodeTest.Services.Exceptions;

namespace SwordITS.CodeTest.Web.Controllers
{
    [ApiController]
    [Route("candidates")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateService candidateService;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService)
        {
            this.candidateService = candidateService ?? throw new ArgumentNullException(nameof(candidateService));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            return Ok(this.candidateService.GetAllCandidates());
        }

        [HttpGet("{id}")]
        public ActionResult<Candidate> GetById(int id)
        {
            try
            {
                return Ok(this.candidateService.GetCandidate(id));
            }
            catch (CandidateNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.candidateService.DeleteCandidate(id);
                return NoContent();
            }
            catch (CandidateNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Candidate> Create(Candidate candidate)
        {
            try
            {
                Candidate createdCandidate = this.candidateService.CreateCandidate(candidate);
                return Ok(createdCandidate);
            }
            catch (CandidateAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Candidate candidate)
        {
            try 
            {
                if (this.candidateService.CandidateExists(id))
                {
                    this.candidateService.UpdateCandidate(candidate);
                    
                    return NoContent();
                }

                this.candidateService.CreateCandidate(candidate);
                return CreatedAtAction(nameof(GetById), new { id = id }, candidate);
            }
            catch (CandidateValidationFailedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}