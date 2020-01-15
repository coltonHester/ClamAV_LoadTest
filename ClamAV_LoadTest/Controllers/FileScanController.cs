using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using nClam;

namespace ClamAV_LoadTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FileScanController : ControllerBase
	{
		// GET api/filescan
		[HttpGet]
		public ActionResult<string> Get()
		{
			try
			{
				ClamClient clam = new ClamClient("localhost", 3310);
				//string fileName1 = "C:\\Users\\ColtonHester\\Downloads\\eicar.com.txt";
				//string fileName2 = "C:\\Users\\ColtonHester\\Pictures\\AssurantTest\\Test.pdf";
				//string fileName1 = "C:\\Users\\ColtonHester\\Downloads\\nihongo_grammar_guide.pdf";
				string fileName1 = "C:\\Users\\ColtonHester\\Downloads\\1126072019 Council Meeting Package_Externals.pdf";
				string fileName2 = "C:\\Users\\ColtonHester\\Downloads\\eicar.com.txt";
				Task<ClamScanResult> scanResult1 = clam.SendAndScanFileAsync(fileName1);
				Task<ClamScanResult> scanResult2 = clam.SendAndScanFileAsync(fileName2);

				string output = "FileScan on " + fileName1 + " results:" + scanResult1.Result.RawResult.Replace("stream:", "") + "\n" +
					"FileScan on " + fileName2 + " results:" + scanResult2.Result.RawResult.Replace("stream:", "");

				//using (System.IO.StreamWriter file =
				//			new System.IO.StreamWriter(@"C:\\Users\\ColtonHester\\Downloads\\load_test\\log.txt", true))
				//{
				//	file.WriteLine(logoutput);
				//}

				// test commit 1 - patch test 1 - round 4
				// test commit 2 - patch test 2

				return output;
			}
			catch (Exception ex) {
				return ex.ToString();
			}			
		}
	}
}
