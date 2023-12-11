#region Наследование
class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
class Manager : User
{
    public string Company { get; set; }
}
//Manager is a User, Manager -> User
#endregion
#region Реализация
public interface IMovable
{
    void Move();
}
public class Car : IMovable
{
    public void Move()
    {
        Console.WriteLine("Машина едет");
    }
}
//Car ---> IMovable
#endregion
#region Ассоциация
class Team
{
    string Name { get; set; }
}
class Player
{
    public Team Team { get; set; }
}
//Player *->1 Team (Много игроков одна команда)
#endregion
#region Композиция
public class ElectricEngine
{ }

public class CAR
{
    ElectricEngine engine;
    public CAR()
    {
        engine = new ElectricEngine();
    }
}
//CAR has a ElectricEngine, CAR <|>-> ElectricEngine
#endregion
#region Агрегация
public abstract class Engine
{ }

public class _Car
{
    Engine engine;
    public _Car(Engine eng)
    {
        engine = eng;
    }
}
//_Car has a Engine, CAR <>-> Engine
#endregion