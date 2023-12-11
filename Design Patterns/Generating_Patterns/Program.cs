using Generating_Patterns;
#region Factory Method


// Строительная фирма с использованием кирпичей
ConstructionFirm firm = new PanelConstructionFirm("ООО КирпичСтрой");
Building house1 = firm.Construct();

// Частный застройщик с использованием дерева
firm = new WoodConstructionFirm("Частный застройщик");
Building house2 = firm.Construct();
#endregion

#region Abstract Factory


// Создаем героя-эльфа с использованием фабрики эльфов
Hero elf = new Hero(new ElfFactory());
elf.Hit();
elf.Defend();

// Создаем героя-воина с использованием фабрики воинов
Hero warrior = new Hero(new WarriorFactory());
warrior.Hit();
warrior.Defend();
#endregion

#region Singleton


// Инициализируем устройство
Device device = new Device();
device.Initialize("Unix");

// Устанавливаем платформу устройства с использованием синглтона
device.Platform = Platform.GetInstance("Linux");
#endregion

#region Prototype


// Создаем квадрат и его клон
IShape shape = new Square(30, 40);
IShape clonedShape = shape.Duplicate();
shape.Display();
clonedShape.Display();

// Создаем овал и его клон
shape = new Oval(30);
clonedShape = shape.Duplicate();
shape.Display();
clonedShape.Display();
#endregion

#region Builder


// Пекарь готовит коричневый хлеб
Baker chef = new Baker();
BreadBuilder builder = new BrownBreadBuilder();
Bread brownBread = chef.Bake(builder);
Console.WriteLine(brownBread.ToString());

// Пекарь готовит белый хлеб
builder = new WhiteBreadBuilder();
Bread whiteBread = chef.Bake(builder);
Console.WriteLine(whiteBread.ToString());
#endregion
