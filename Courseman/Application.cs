using Courseman.Common.Entitys;
using Courseman.Common.Helpers;
using Courseman.Common.Interfaces;

namespace Courseman;

public class Application
{
    /**
		 * Uygulama sınıfı
		 * 
		 * Bu sınıfı tanımlama amacım tüm herşeyin Program.cs içerisinde olmasını istemememdi. Program.cs'i bir başlatıcı olarak düşünerek
		 * static Run metoduna sahip olan bir uygulama sınıfı oluşturdum. Bu Run metodu içerisinde sınıf tanımlamalarını ve uygulamanın genel yapısını
		 * barındırıyor.
		 * 
		 * Aynı zamanda bu tanımlama sayesinde konsol aplikasyonlarında yaşanan hatalı girdilerde uygulamayı dinamik şekilde yeniden başlatabiliyorum.
		 * Yeniden başlatma yanlış algılanmasın. Aynı process içerisinde tekrardan tanımlamaları yapıyorum.
		 */
    private static readonly List<IWizardable> Courses = new()
    {
        new Course("Java Programlama"),
        new Course("C# Programlama")
    };

    private static readonly List<IWizardable> Students = new()
    {
        new Student("Enes", 22, 63673031350),
        new Student("Emin", 21, 48561842566)
    };

    private static readonly List<IWizardable> Academicians = new()
    {
        new Academician("Tugba"),
        new Academician("Ömer")
    };

    /**
		 * Çalıştırma metodu
		 - Sınıf açıklamasından`bu tanımlama sayesinde konsol aplikasyonlarında yaşanan hatalı girdilerde uygulamayı dinamik şekilde yeniden başlatabiliyorum.
		 */
    public static int Run()
    {
        WriteLine("Ortalama kurs puanı hesaplama programına hoşgeldiniz.", true);
        WriteLine(
            "Lütfen alttaki kurslardan puanını hesaplamak istediğiniz kursu seçiniz:\nYeni bir kurs oluşturmak isterseniz -1 yazabilirsiniz.");

        for (var i = 0; i < Academicians.ToArray().Length; i++)
        {
            var academician = (Academician)Academicians.ElementAt(i);
            if (academician.Courses.ToArray().Length == 0) academician.AddCourse((Course)Courses.ElementAt(i));
        }

        for (var i = 0; i < Courses.ToArray().Length; i++)
        {
            var currentCourse = (Course)Courses.ElementAt(i);
            WriteLine("{0}: {1} (Akademisyen: {2})", false, i, currentCourse.Name,
                currentCourse.Academician.Name);
        }

        var selectedCourseIndex = Input.ReadOptions(Courses, true);

        if (selectedCourseIndex == -1)
        {
            var course = new Course();

            if (!Wizard.Mount(
                    course,
                    new Course(), // Varsayılan değerler için yeni bir boş sınıf gönderiyorum
                    true,
                    "Kurs oluşturma sihirbazına hoşgeldiniz",
                    "(Sihirbazdan çıkmak için -1 yazabilirsiniz"
                )) return Run();

            Courses.Add(course);

            WriteLine("{0} adlı kurs başarıyla oluşturuldu", true, course.Name);
            Thread.Sleep(1000);

            return Run();
        }

        var selectedCourse = (Course)Courses.ElementAt(selectedCourseIndex);

        if (selectedCourse.Academician.Name == new Course().Academician.Name)
        {
            WriteLine(
                "{0} kursu için lütfen alttaki akademisyenlerden birini seçin:\nYeni bir akademisyen oluşturmak istiyorsanız -1 yazabilirsiniz.",
                true, selectedCourse.Name);

            for (var i = 0; i < Academicians.ToArray().Length; i++)
            {
                var currentAcademician = (Academician)Academicians.ElementAt(i);
                WriteLine("{0}: {1}", false, i, currentAcademician.Name);
            }

            var selectedAcademicianIndex = Input.ReadOptions(Academicians, true);

            if (selectedAcademicianIndex == -1)
            {
                var academician = new Academician();

                if (!Wizard.Mount(
                        academician,
                        new Academician(),
                        true,
                        "Akademisyen oluşturma sihirbazına hoşgeldiniz",
                        "(Sihirbazdan çıkmak için -1 yazabilirsiniz)"
                    )) return Run();

                Academicians.Add(academician);

                WriteLine("{0} adlı akademisyen başarıyla eklendi.", true, academician.Name);
                Thread.Sleep(1000);

                return Run();
            }

            selectedCourse.AttachAcademician((Academician)Academicians.ElementAt(selectedAcademicianIndex));
        }

        WriteLine("{0} kursu için {1} adlı akademisyenle devam ediliyor...", true, selectedCourse.Name,
            selectedCourse.Academician.Name);
        Thread.Sleep(500);

        WriteLine(
            "{0} kursu için lütfen alttaki öğrencilerden birini seçiniz:\nYeni bir öğrenci oluşturmak istiyorsanız -1 yazabilirsiniz.",
            true, selectedCourse.Name);

        for (var i = 0; i < Students.ToArray().Length; i++)
        {
            var currentStudent = (Student)Students.ElementAt(i);
            WriteLine("{0}: {1}", false, i, currentStudent.Name);
        }

        var selectedStudentIndex = Input.ReadOptions(Students, true);

        if (selectedStudentIndex == -1)
        {
            var student = new Student();

            if (!Wizard.Mount(
                    student,
                    new Student(),
                    true,
                    "Öğrenci oluşturma sihirbazına hoşgeldiniz",
                    "(Sihirbazdan çıkmak için -1 yazabilirsiniz)"
                )) return Run();

            Students.Add(student);

            WriteLine("{0} adlı öğrenci başarıyla eklendi", true, student.Name);
            Thread.Sleep(1000);

            return Run();
        }

        WriteLine(
            "{0} adlı eğitmenin vermiş olduğu {1} kursundan aldığınız vize notunu giriniz:",
            true,
            selectedCourse.Academician.Name,
            selectedCourse.Name
        );
        var midtermValue = Input.ReadDouble(0, 100);

        WriteLine(
            "{0} adlı eğitmenin vermiş olduğu {1} kursundan aldığınız final notunu giriniz:",
            true,
            selectedCourse.Academician.Name,
            selectedCourse.Name
        );
        var finalValue = Input.ReadDouble(0, 100);

        var averagePoint = selectedCourse.CalculatePoint(midtermValue, 0) +
                           selectedCourse.CalculatePoint(finalValue, 1);
        WriteLine(
            "{0} adlı kurstan {1:0.00} notu ile {2}.",
            true,
            selectedCourse.Name,
            averagePoint,
            averagePoint >= 50 ? "geçtiniz" : "kaldınız"
        );

        return 1;
    }

    public static void WriteLine(string message, bool clear = false, params dynamic[] entitys)
    {
        if (clear)
            Console.Clear();

        if (!string.IsNullOrEmpty(message))
            Console.WriteLine(message, entitys);
    }
}