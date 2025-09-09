using Microsoft.AspNetCore.Mvc;
using PROG6212_CRMS_PART_1.Models;

namespace PROG6212_CRMS_PART_1.Controllers
{
    public class ClaimController : Controller
    {
        // Display the form for submitting a new claim
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        public IActionResult Claim()
        {
            return View();
        }

        // Handle the submission of the new claim
        [HttpPost]
        public IActionResult SubmitClaim(ClaimModel model)
        {
            if (ModelState.IsValid)
            {
                // Handle file uploads
                if (model.SupportingDocuments != null && model.SupportingDocuments.Any())
                {
                    foreach (var file in model.SupportingDocuments)
                    {
                        if (file != null && file.Length > 0)
                        {
                            // Example: save file to wwwroot/uploads
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }
                }

                // Save claim details to the database
                // TODO: Implement saving logic (e.g., EF Core DB context)

                return RedirectToAction("ClaimSubmitted");
            }

            // If model is invalid, return the same view with validation messages
            return View(model);
        }

        // View to confirm the claim has been submitted
        public IActionResult ClaimSubmitted()
        {
            return View();
        }

        // View for claims pending verification
        public IActionResult PendingVerification()
        {
            var claims = new List<ClaimModel>(); // TODO: Fetch from DB
            return View(claims);
        }

        // Verify a specific claim
        public IActionResult Verify(int id)
        {
            // TODO: Implement claim verification logic
            return RedirectToAction("PendingVerification");
        }

        // View for claims pending approval
        public IActionResult PendingApproval()
        {
            var claims = new List<ClaimModel>(); // TODO: Fetch from DB
            return View(claims);
        }

        // Approve a specific claim
        public IActionResult Approve(int id)
        {
            // TODO: Implement claim approval logic
            return RedirectToAction("PendingApproval");
        }
    }
}

