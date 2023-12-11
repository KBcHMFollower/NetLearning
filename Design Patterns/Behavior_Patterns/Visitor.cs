using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Patterns
{
    // Абстрактный элемент (Element): Пациент
    public abstract class Patient
    {
        public string Name { get; }

        public Patient(string name)
        {
            Name = name;
        }

        // Метод принятия посещения (посетителя)
        public abstract void Accept(IVisitor visitor);
    }

    // Конкретный элемент (ConcreteElement): Пациент с высоким давлением
    public class HighBloodPressurePatient : Patient
    {
        public HighBloodPressurePatient(string name) : base(name) { }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitHighBloodPressurePatient(this);
        }
    }

    // Конкретный элемент (ConcreteElement): Пациент с диабетом
    public class DiabetesPatient : Patient
    {
        public DiabetesPatient(string name) : base(name) { }

        public override void Accept(IVisitor visitor)
        {
            visitor.VisitDiabetesPatient(this);
        }
    }

    // Интерфейс посетителя (Visitor)
    public interface IVisitor
    {
        void VisitHighBloodPressurePatient(HighBloodPressurePatient patient);
        void VisitDiabetesPatient(DiabetesPatient patient);
    }

    // Конкретный посетитель (ConcreteVisitor): Врач
    public class Doctor : IVisitor
    {
        public void VisitHighBloodPressurePatient(HighBloodPressurePatient patient)
        {
            Console.WriteLine($"Врач обследует пациента {patient.Name} с высоким давлением.");
            // Логика обследования пациента с высоким давлением
        }

        public void VisitDiabetesPatient(DiabetesPatient patient)
        {
            Console.WriteLine($"Врач обследует пациента {patient.Name} с диабетом.");
            // Логика обследования пациента с диабетом
        }
    }
}
