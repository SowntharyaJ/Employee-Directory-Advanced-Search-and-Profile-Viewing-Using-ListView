using System.Collections.ObjectModel;

namespace ListViewMAUI
{
    public class EmployeeDirectoryRepository
    {
        private List<Employee> _employees = new();
        public EmployeeDirectoryRepository()
        {                        
            PopulateEmployees();
        }

        public ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>(_employees);
        }

        public List<string> GetDepartments()
        {
            return _employees.Select(e => e.Department).Distinct().OrderBy(d => d).ToList();
        }

        public List<string> GetSkills()
        {
            var allSkills = _employees.SelectMany(e => e.Skills).Distinct().OrderBy(s => s).ToList();
            return allSkills;
        }

        private void PopulateEmployees()
        {                        
            // A dictionary to map positions to their departments and skills
            var roleMap = new Dictionary<string, (string Dept, string[] Skills, string Bio, string Manager)>
            {
                { position[0], (department[0], skills[0], bio[0], manager[0]) }, // Senior Software Engineer -> Engineering
                { position[1], (department[1], skills[1], bio[1] ,manager[1]) }, // Marketing Manager -> Marketing
                { position[2], (department[0], skills[2], bio[0], manager[0]) }, // DevOps Engineer -> Engineering
                { position[3], (department[2], skills[3], bio[2], manager[2]) }, // UX Designer -> Design
                { position[4], (department[3], skills[4], bio[3] , manager[3])}, // Sales Representative -> Sales
                { position[5], (department[4], skills[5], bio[4], manager[4]) }  // HR Manager -> HR
            };

            int girlsCount = 0, boysCount = 0;
            for (int i = 0; i < (employeeNames_Boys.Count() + employeeName_Girls.Count()); i++)
            {
                // Cycle through positions to assign roles
                string currentPosition = position[i % position.Length];
                var roleDetails = roleMap[currentPosition];                
                var employee = new Employee
                {
                    Id = i + 1,                    
                    Position = currentPosition,
                    Department = roleDetails.Dept,
                    Skills = roleDetails.Skills,
                    Location = location[i % location.Length],
                    ImageUrl = "people_circle" + (i % 19) + ".png",
                    Bio = roleDetails.Bio,
                    PhoneNumber = "+1 - 555 - 010"+i,
                    DateOfJoining = new DateTime(2020, 3, (i +1) > 30 ? (i%30)+1 : i+1),                
                    IsActive = true,
                    Manager = roleDetails.Manager,
                    BloodGroup = bloodGroup[i % bloodGroup.Length],
                    EmergencyPhone = emergencyphone[i % emergencyphone.Length],
                    Relation = relation[i % relation.Length],
                    Address = address[i % address.Length],
                    YearOfExperience = yearofExperience[i % yearofExperience.Length],
                    DateOfBirth = new DateTime(1990, 5, 20),
                    IsVerified = true,
                };

                if (imagePosition.Contains(i % 19))
                {
                    var currentName = employeeNames_Boys[boysCount++ % 32];
                    employee.FirstName = currentName.Split(' ')[0];
                    employee.LastName = currentName.Split(' ')[1];
                    employee.Email = GenerateEmail(currentName);
                }
                else
                {
                    var currentName = employeeName_Girls[girlsCount++ % 93];
                    employee.FirstName = currentName.Split(' ')[0];
                    employee.LastName = currentName.Split(' ')[1];
                    employee.Email = GenerateEmail(currentName);
                }
                
                _employees.Add(employee);
            }
        }

        readonly string[][] skills = new string[][] {
            new string[] { "C#", ".NET", "Azure", "React" }, // Engineering
            new string[] { "Digital Marketing", "SEO", "Content Strategy", "Analytics" }, // Marketing
            new string[] { "Docker", "Kubernetes", "AWS", "Jenkins", "Python" }, // DevOps (a subset of Engineering)
            new string[] { "Figma", "Adobe XD", "User Research", "Prototyping" }, // Design
            new string[] { "CRM", "Lead Generation", "Negotiation", "Customer Relations" }, // Sales
            new string[] { "Recruitment", "Employee Relations", "Performance Management", "Training" } // HR
        };

        readonly string[] bio = new string[]
        {
            "Experienced software engineer with expertise in full-stack development.",
            "Creative marketing professional with a passion for brand development.",
            "DevOps specialist focused on automation and cloud infrastructure.",
            "User experience designer with a focus on creating intuitive interfaces.",
            "Results-driven sales professional with excellent communication skills."
        };

        /// <summary>
        /// Helper function to generate an email from a full name.
        /// </summary>
        private string GenerateEmail(string fullName)
        {
            string[] nameParts = fullName.Trim().Split(' ');
            if (nameParts.Length < 2) return "invalid.name@company.com";
            string firstName = nameParts[0].ToLower();
            string lastName = nameParts[1].ToLower();
            return $"{firstName}.{lastName}@company.com";
        }

        readonly int[] imagePosition = new int[]
        {
            5,
            8,
            12,
            14,
            18
        };

        readonly string[] manager = new string[]
        {
            "Sarah Johnson",
            "Michael Brown",
            "David Wilson",
            "Lisa Anderson",
            "CEO"
        };

        readonly string[] location = new string[]
        {
            "New York, NY",
            "Los Angeles, CA",
            "Seattle, WA",
            "Austin, TX",
            "Chicago, IL",
            "Boston, MA"
        };

        readonly string[] position = new string[]
        {
            "Senior Software Engineer",
            "Marketing Manager",
            "DevOps Engineer" ,
            "UX Designer",
            "Sales Representative",
            "HR Manager"
        };

        readonly string[] department = new string[]
        {
            "Engineering",
            "Marketting",
            "Design",
            "Sales",
            "HR"
        };

        readonly string[] bloodGroup = new string[]
        {
            "A+",
            "B+",
            "O+",
            "AB+",
            "A-",
            "B-",
            "O-",
            "AB-"
        };

        readonly string[] emergencyphone = new string[]
        {
            "(91) 98765 43210",
            "(91) 87654 32109",
            "(91) 76543 21098",
            "(91) 65432 10987",
            "(91) 54321 09876",
        };

        readonly string[] relation = new string[]
        {
            "Father",
            "Mother",
            "Spouse",
            "Brother",
            "Sister"
        };

        readonly string[] address = new string[]
        {
            "123 Main St, New York, NY 10001",
            "456 Oak Ave, Los Angeles, CA 90001",
            "789 Pine Ln, Seattle, WA 98101",
            "101 Maple Dr, Austin, TX 78701",
            "212 Birch Rd, Chicago, IL 60601",
        };
        readonly int[] yearofExperience = new int[]
        {
            2,
            5,
            1,
            3,
            10,
        };

        readonly string[] employeeName_Girls = new string[]
        {
            "Kyle Smith",
            "Gina Johnson",
            "Brenda Williams",
            "Danielle Brown",
            "Fiona Jones",
            "Lila Garcia",
            "Jennifer Miller",
            "Liz Davis",
            "Pete Rodriguez",
            "Katie Martinez",
            "Vince Hernandez",
            "Fiona Lopez",
            "Liam Gonzalez",
            "Georgia Wilson",
            "Elijah Anderson",
            "Alivia Thomas",
            "Evan Taylor",
            "Ariel Moore",
            "Vanessa Jackson",
            "Gabriel Martin",
            "Angelina Lee",
            "Eli Perez",
            "Remi Thompson",
            "Levi White",
            "Alina Harris",
            "Layla Sanchez",
            "Ella Clark",
            "Mia Ramirez",
            "Emily Lewis",
            "Clara Robinson",
            "Lily Walker",
            "Melanie Young",
            "Rose Allen",
            "Brianna King",
            "Bailey Wright",
            "Juliana Scott",
            "Valerie Torres",
            "Hailey Nguyen",
            "Daisy Hill",
            "Sara Flores",
            "Victoria Green",
            "Grace Adams",
            "Layla Nelson",
            "Josephine Baker",
            "Jade Hall",
            "Evelyn Rivera",
            "Mila Campbell",
            "Camila Mitchell",
            "Chloe Carter",
            "Zoey Roberts",
            "Nora Smith",
            "Ava Johnson",
            "Natalia Williams",
            "Eden Brown",
            "Cecilia Jones",
            "Finley Garcia",
            "Trinity Miller",
            "Sienna Davis",
            "Rachel Rodriguez",
            "Sawyer Martinez",
            "Amy Hernandez",
            "Ember Lopez",
            "Rebecca Gonzalez",
            "Gemma Wilson",
            "Catalina Anderson",
            "Tessa Thomas",
            "Juliet Taylor",
            "Zara Moore",
            "Malia Jackson",
            "Samara Martin",
            "Hayden Lee",
            "Ruth Perez",
            "Kamila Thompson",
            "Freya White",
            "Kali Harris",
            "Leiza Sanchez",
            "Myla Clark",
            "Daleyza Ramirez",
            "Maggie Lewis",
            "Zuri Robinson",
            "Millie Walker",
            "Lilliana Young",
            "Kaia Allen",
            "Nina King",
            "Paislee Wright",
            "Raelyn Scott",
            "Talia Torres",
            "Cassidy Nguyen",
            "Rylie Hill",
            "Laura Flores",
            "Gracelynn Green",
            "Heidi Adams",
            "Kenzie Nelson"
        };

        readonly string[] employeeNames_Boys = new string[]
        {
            "Irene Baker",
            "Watson Hall",
            "Ralph Rivera",
            "Torrey Campbell",
            "William Mitchell",
            "Bill Carter",
            "Howard Roberts",
            "Daniel Smith",
            "Frank Johnson",
            "Jack Williams",
            "Oscar Brown",
            "Larry Jones",
            "Holly Garcia",
            "Steve Miller",
            "Zeke Davis",
            "Aiden Rodriguez",
            "Jackson Martinez",
            "Mason Hernandez",
            "Jacob Lopez",
            "Jayden Gonzalez",
            "Ethan Wilson",
            "Noah Anderson",
            "Lucas Thomas",
            "Brayden Taylor",
            "Logan Moore",
            "Caleb Jackson",
            "Caden Martin",
            "Benjamin Lee",
            "Xaviour Perez",
            "Ryan Thompson",
            "Connor White",
            "Michael Harris"
        };

    }
}