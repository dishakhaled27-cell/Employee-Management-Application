class Department
{
 public int departId {  get; set; }
 public string departName { get; set; }
 public void print()
    {
        Console.WriteLine($"ID {departId}");
        Console.WriteLine($"Name {departName}");
    }
}
abstract class StaffMember
{
   public int employee {  get; set; }
    public string name { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public abstract double Pay();
    public virtual void Print ()
    {
        Console.WriteLine($"Name : {name}");
        Console.WriteLine($"Phone : {phone}");
        Console.WriteLine($"Email : {email}");
    }
} 
abstract class Employee : StaffMember { 

  public string SocialSecurityNumber { get; set; }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"SSN {SocialSecurityNumber}");
    }


}
class Volunteer : StaffMember
{
    public double amount { get; set; }
    public override double Pay()
    {
        return amount;
    }
    public override void Print()
    {
         base.Print() ;
        Console.WriteLine($"Amount : {amount}");
    }
}
class HourlyEmployee : Employee
{
    public double hours { get; set; }
    public double rate { get; set; }
    public override double Pay()
    {
        return hours * rate;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Hours : {hours}");
        Console.WriteLine($"Rate : {rate}");
        Console.WriteLine($"Pay : {Pay()}");
    }

}
class SalariedEmployee : Employee
{
    public double Salary { get; set; }
    public override double Pay()
    {
        return Salary;
    }
}
class ExecutiveEmployee : Employee
{
    public double Salary { get; set; }
    public double Bonus { get; set; }
    public override double Pay()
    {
        return Salary + Bonus;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Salary : {Salary}");
        Console.WriteLine($"Bonus : {Bonus}");
        Console.WriteLine($"Pay : {Pay()}");
    }
}
class CommissionEmployee : Employee
{
    public double Target { get; set; }
    public override double Pay()
    {
        return Target * 0.05;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Target : {Target}");
        Console.WriteLine($"Pay : {Pay()}");
    }
}
class Budget
{
    public int Id { get; set; }
    public double Value { get; set; }
    public void IncreaseBudget(double amount)
    {
        Value += amount;
    }
}
class Project
{
    public int Id { get; set; }
    public string Location { get; set; }
    public double CurrentCost { get; set; }
    public Employee Manager { get; set; }
    public List<Budget> Budgets { get; set; }
        = new List<Budget>();
    public double CalculateTotalBudget()
    {
        double total = 0;
        foreach (Budget budget in Budgets)
        {
            total += budget.Value;
        }
        return total;
    }
}
class Staff
{
    public List<StaffMember> Members { get; set; }
        = new List<StaffMember>();
    public void AddMember(StaffMember member)
    {
        Members.Add(member);
        Console.WriteLine("Member Added Successfully");
    }
    public StaffMember Search(int id)
    {
        foreach (StaffMember member in Members)
        {
            if (member.employee == id)
            {
                return member;
            }
        }

        return null;
    }
    public void DeleteMember(int id)
    {
        StaffMember member = Search(id);

        if (member != null)
        {
            Members.Remove(member);
            Console.WriteLine("Member Deleted");
        }
        else
        {
            Console.WriteLine("Member Not Found");
        }
    }
    public void EditMember(int id)
    {
        StaffMember member = Search(id);

        if (member != null)
        {
            Console.Write("Enter New Name: ");
            member.name = Console.ReadLine();

            Console.Write("Enter New Phone: ");
            member.phone = Console.ReadLine();

            Console.Write("Enter New Email: ");
            member.email = Console.ReadLine();

            Console.WriteLine("Updated Successfully");
        }
        else
        {
            Console.WriteLine("Member Not Found");
        }
    }
    public void ShowAll()
    {
        foreach (StaffMember member in Members)
        {
            member.Print();

            Console.WriteLine($"Pay: {member.Pay()}");
            Console.WriteLine("----------------------");
        }
    }
    public int Count()
    {
        return Members.Count;
    }
    public void CallPayroll()
    {
        double total = 0;

        foreach (StaffMember member in Members)
        {
            total += member.Pay();
        }
        Console.WriteLine($"Total Payroll: {total}");
    }
}
class Program
{
    static void Main(string[] args)
    {
       Staff staff = new Staff();
        Volunteer v1 = new Volunteer()
        {
            employee = 1,
            name = "Ahmed",
            phone = "01012345678",
            email = "ahmed@gmail.com",
            amount = 2000
        };
        HourlyEmployee h1 = new HourlyEmployee()
        {
            employee = 2,
            name = "Mohamed",
            phone = "01112345678",
            email = "mohamed@gmail.com",
            SocialSecurityNumber = "123456",
            hours = 160,
            rate = 50
        };
        SalariedEmployee s1 = new SalariedEmployee()
        {
            employee = 3,
            name = "Ali",
            phone = "01212345678",
            email = "ali@gmail.com",
            SocialSecurityNumber = "654321",
            Salary = 10000
        };

        ExecutiveEmployee e1 = new ExecutiveEmployee()
        {
            employee = 4,
            name = "Mostafa",
            phone = "01098765432",
            email = "mostafa@gmail.com",
            SocialSecurityNumber = "987654",
            Salary = 15000,
            Bonus = 5000
        };
        CommissionEmployee c1 = new CommissionEmployee()
        {
            employee = 5,
            name = "Omar",
            phone = "01512345678",
            email = "omar@gmail.com",
            SocialSecurityNumber = "456789",
            Target = 20000
        };

        staff.AddMember(v1);
        staff.AddMember(h1);
        staff.AddMember(s1);
        staff.AddMember(e1);
        staff.AddMember(c1);

        int choice;

        do
        {
            Console.WriteLine("\n===== Staff Management System =====");
            Console.WriteLine("1. Add Volunteer");
            Console.WriteLine("2. Show All Members");
            Console.WriteLine("3. Search Member");
            Console.WriteLine("4. Edit Member");
            Console.WriteLine("5. Delete Member");
            Console.WriteLine("6. Count Members");
            Console.WriteLine("7. Calculate Total Payroll");
            Console.WriteLine("0. Exit");

            Console.Write("Enter Choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Volunteer v = new Volunteer();

                    Console.Write("Enter ID: ");
                    v.employee = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    v.name = Console.ReadLine();

                    Console.Write("Enter Phone: ");
                    v.phone = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    v.email = Console.ReadLine();

                    Console.Write("Enter Amount: ");
                    v.amount = double.Parse(Console.ReadLine());

                    staff.AddMember(v);
                    break;

                case 2:
                    staff.ShowAll();
                    break;

                case 3:
                    Console.Write("Enter ID: ");
                    int searchId = int.Parse(Console.ReadLine());

                    StaffMember member = staff.Search(searchId);

                    if (member != null)
                    {
                        member.Print();
                        Console.WriteLine($"Pay: {member.Pay()}");
                    }
                    else
                    {
                        Console.WriteLine("Member Not Found");
                    }
                    break;

                case 4:
                    Console.Write("Enter ID: ");
                    int editId = int.Parse(Console.ReadLine());

                    staff.EditMember(editId);
                    break;

                case 5:
                    Console.Write("Enter ID: ");
                    int deleteId = int.Parse(Console.ReadLine());

                    staff.DeleteMember(deleteId);
                    break;

                case 6:
                    Console.WriteLine($"Total Members: {staff.Count()}");
                    break;

                case 7:
                    staff.CallPayroll();
                    break;

                case 0:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }

        } while (choice != 0);
    }
}



