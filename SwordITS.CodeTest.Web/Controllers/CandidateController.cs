using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwordITS.CodeTest.Model;
using SwordITS.CodeTest.Services;

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
            if (!this.candidateService.CandidateExists(id))
            {
                return NotFound();
            }

            return Ok(this.candidateService.GetCandidate(id));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!this.candidateService.CandidateExists(id))
            {
                return NotFound();
            }

            this.candidateService.DeleteCandidate(id);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<Candidate> Create(Candidate candidate)
        {
            if (this.candidateService.CandidateExists(candidate.Id))
            {
                return BadRequest($"User with id `{candidate.Id}` already exists.");
            }

            Candidate createdCandidate = null;
            try
            {
                createdCandidate = this.candidateService.CreateCandidate(candidate);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return createdCandidate;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Candidate candidate)
        {
            if (this.candidateService.CandidateExists(id))
            {
                this.candidateService.UpdateCandidate(candidate);
                
                return NoContent();
            }

            this.candidateService.CreateCandidate(candidate);
            return CreatedAtAction(nameof(GetById), new { id = id }, candidate);
        }

    }
}