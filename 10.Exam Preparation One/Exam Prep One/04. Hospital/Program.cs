using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> doctorPatientList = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> departmentPatientList = new Dictionary<string, List<string>>();

            Dictionary<string, Dictionary<int, List<string>>> departmentRoomPatientList = new Dictionary<string, Dictionary<int, List<string>>>();

            int room = 1;

            List<string> resultArr = new List<string>();

            string[] command2 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var command = command2.Where(e => e != " ").ToArray();

            while (command[0] != "Output")
            {
                string department = string.Empty;
                string doctor = string.Empty;
                string patient = string.Empty;

                if (command.Length == 5)
                {
                    department = command[0] + " " + command[1];
                    doctor = command[2] + " " + command[3];
                    patient = command[4];
                }
                else
                {
                    department = command[0];
                    doctor = command[1] + " " + command[2];
                    patient = command[3];
                }

                var doctorsPatients = new List<string>();

                if (doctorPatientList.ContainsKey(doctor))
                {
                    doctorsPatients = doctorPatientList[doctor].ToList();
                }

                if (!doctorsPatients.Contains(patient))
                    doctorsPatients.Add(patient);

                doctorPatientList[doctor] = doctorsPatients;

                var departmentPatients = new List<string>();

                if (departmentPatientList.ContainsKey(department))
                {
                    departmentPatients = departmentPatientList[department].ToList();
                }

                if (!departmentPatients.Contains(patient))
                    departmentPatients.Add(patient);

                departmentPatientList[department] = departmentPatients;

                var roomPatients = new Dictionary<int, List<string>>();
                var patientList = new List<string>();

                if (departmentRoomPatientList.ContainsKey(department))
                {
                    roomPatients = departmentRoomPatientList[department];

                    if (roomPatients[room].Count >= 3)
                    {
                        room++;
                    }
                    if (roomPatients.ContainsKey(room))
                    {
                        patientList = roomPatients[room];
                    }

                }
                else
                {
                    room = 1;
                }

                if(!patientList.Contains(patient))
                    patientList.Add(patient);

                roomPatients[room] = patientList;

                departmentRoomPatientList[department] = roomPatients;

                command = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string[] requiredResult = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
           
            requiredResult = PrintResult(resultArr, doctorPatientList, departmentPatientList, departmentRoomPatientList, requiredResult);

            foreach (var item in resultArr)       
                Console.WriteLine(item);
        }

        private static string[] PrintResult(List<string> resultArr, Dictionary<string, List<string>> doctorPatientList, Dictionary<string, List<string>> departmentPatientList, Dictionary<string, Dictionary<int, List<string>>> departmentRoomPatientList, string[] requiredResult)
        {
            while (requiredResult[0] != "End")
            {

                if (requiredResult.Length == 1)
                {
                    if (departmentPatientList.Keys.Any(d => d == requiredResult[0]))
                    {
                        foreach (var departamentWithPatients in departmentPatientList)
                        {
                            string currentDepartment = departamentWithPatients.Key;
                            var patients = departamentWithPatients.Value.ToList();

                            if (currentDepartment == requiredResult[0])
                            {
                                foreach (var p in patients)
                                    resultArr.Add(p);
                                break;
                            }

                        }
                    }

                }

                if (requiredResult.Length == 2) {
					
                    if (doctorPatientList.Keys.Any(k => k == requiredResult[0] + " " + requiredResult[1]))
                    {
                        foreach (var doctorPatients in doctorPatientList)
                        {
                            string currentDoctor = doctorPatients.Key;
                            var patients = doctorPatients.Value.ToList();

                            if (currentDoctor == requiredResult[0] + " " + requiredResult[1])
                            {
                                patients.Sort();
                                foreach (var p in patients)
                                    resultArr.Add(p);
                                break;
                            }
                        }
                    }
                    else if (departmentPatientList.Keys.Any(d => d == requiredResult[0] + " " + requiredResult[1]))
                    {
                        foreach (var departamentWithPatients in departmentPatientList)
                        {
                            string currentDepartment = departamentWithPatients.Key;
                            var patients = departamentWithPatients.Value.ToList();

                            if (currentDepartment == requiredResult[0] + " " + requiredResult[1])
                            {
                                foreach (var p in patients)
                                    resultArr.Add(p);
                                break;
                            }

                        }
                    }
                    else if (requiredResult.Last().Any(c => char.IsDigit(c)))
                    {
                        string requiredDepartment = requiredResult[0];

                        int requiredRoom = int.Parse(requiredResult[1]);
						
                        departmentRoomPatientList[requiredDepartment][requiredRoom].Sort();
                        foreach (var patient in departmentRoomPatientList[requiredDepartment][requiredRoom])
                        {
                            resultArr.Add(patient);
                        }
                    }
                }
                if (requiredResult.Length == 3)
                {
  
                if (requiredResult.Last().Any(c => char.IsDigit(c)))
                    {
                        string requiredDepartment = requiredResult[0] + " " + requiredResult[1];

                        int requiredRoom = int.Parse(requiredResult.Last());
             
                        departmentRoomPatientList[requiredDepartment][requiredRoom].Sort();
                        foreach (var patient in departmentRoomPatientList[requiredDepartment][requiredRoom])
                        {
                            resultArr.Add(patient);
                        }
                    }
                }

                requiredResult = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            return requiredResult;
        }
    }
}
Emergency department Petar Petrov Ventsi
Oncology Ivaylo Kenov Valio
Emergency Mariq Mircheva Simo
Emergency department Genka Shikerova Simon
Emergency Ivaylo Kenov NuPogodi
Emergency department Gosho Goshov Esmeralda
Oncology Gosho Goshov Cleopatra
Output
Emergency department 1
End


*/
