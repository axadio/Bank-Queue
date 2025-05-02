using System.Collections.Generic;

namespace Bank_Queue
{
    public partial class MainPage : ContentPage
    {
        private string[] families = new string[]
        {
            "Abdullayev", "Aliyev", "Asqarov", "Berkov", "Djanibekov", "Djumaniyazov", "Esanov", "Farukov", "Gafurov", "Guliyev",
            "Ismailov", "Jalilov", "Kamolov", "Khamidov", "Khusainov", "Mahmudov", "Makhmudov", "Miroshnichenko", "Mujdabaev", "Mustafaev",
            "Nabiyev", "Omarov", "Parpiev", "Qodirov", "Rakhmatov", "Rasulov", "Ruziev", "Sabirov", "Saidov", "Salimov",
            "Samiyev", "Shukurov", "Sultanov", "Tajiev", "Toshmatov", "Umarov", "Usmonov", "Vahobov", "Vahidov", "Veliyev",
            "Voziev", "Yusupov", "Ziyodov", "Zukhriddinov", "Akbarov", "Azimov", "Babayev", "Bachayev", "Buzhiev", "Djumaliev",
            "Dastanov", "Ergashev", "Fazilov", "Galibov", "Gulomov", "Iskandarov", "Kamilov", "Khurshidov", "Maqsudov", "Mavlonov",
            "Mikayilov", "Niyatov", "Nargizov", "Nodirov", "Otabekov", "Otajonov", "Pulatov", "Sadriddinov", "Shamsutdinov", "Shermatov",
            "Sohibov", "Talibov", "Tugayev", "Umidov", "Usmanov", "Vahirov", "Vokhidov", "Zafarov", "Zukov", "Yavuzov",
            "Yunusov", "Alimov", "Anvarov", "Bekiyev", "Boshbekov", "Doronin", "Dovudov", "Erkinov", "Farhodov", "Firuzaev",
            "Galiev", "Gavkharov", "Jahongirov", "Jasurov", "Jozibov", "Khasanov", "Khayitov", "Khamzaev", "Malikov", "Murodov",
            "Nafasov", "Narimonov", "Nizomov", "Pirov", "Raufov", "Rasulov", "Rashidov", "Siddiqov", "Tursunov", "Turgunov",
            "Ulmasov", "Yunusova", "Sadriddinova", "Shahrizoda", "Shokirov", "Mavlyanov", "Manzuraev", "Marufov", "Sukhratov", "Farouqov",
            "Khorazov", "Oripov", "Sovurov", "Olimov", "Pulatov", "Mansurov", "Miziev", "Ibrohimov", "Teshayev", "Shamsiev",
            "Shukrulloev", "Akhmedov", "Bahodirov", "Bayazov", "Djangirov", "Gulzorov", "Ubaydullayev", "Bakhodirov", "Qodirov",
            "Rasulov", "Rudakov", "Mubinov", "Taylanov", "Samiyev", "Mukimov", "Sardorov", "Abdullaeva", "Aliyeva", "Ashurova",
            "Berkova", "Djamalova", "Fazilova", "Galieva", "Ismailova", "Jalilova", "Kamolova", "Khamidova", "Khusainova", "Mahmudova",
            "Mikhaylova", "Mujdabaeva", "Mustafaeva", "Nabiyeva", "Omarova", "Parpieva", "Qodirova", "Rakhmatova", "Rasulova", "Ruzieva",
            "Sabirova", "Saidova", "Salimova", "Samiyeva", "Shukurova", "Sultanova", "Tajiyeva", "Toshmatova", "Umidova", "Usmanova"
        };
        int sc1id = 101100, sc2id = 102100, sc3id = 103100, sc4id = 104100;
        int e1id = 105200, e2id = 106200, e3id = 107200, e4id = 108200;
        int hs1id = 109300, hs2id = 110300, hs3id = 111300, hs4id = 112300;
        int d1id = 113400, d2id = 114400, d3id = 115400, d4id = 116400;
        // Sotuv va kredit
        Queue<Button> sc1Queue = new Queue<Button>();
        Queue<Button> sc2Queue = new Queue<Button>();
        Queue<Button> sc3Queue = new Queue<Button>();
        Queue<Button> sc4Queue = new Queue<Button>();

        // Ayirboshlash
        Queue<Button> e1Queue = new Queue<Button>();
        Queue<Button> e2Queue = new Queue<Button>();
        Queue<Button> e3Queue = new Queue<Button>();
        Queue<Button> e4Queue = new Queue<Button>();

        // Qo‘llab-quvvatlash
        Queue<Button> hs1Queue = new Queue<Button>();
        Queue<Button> hs2Queue = new Queue<Button>();
        Queue<Button> hs3Queue = new Queue<Button>();
        Queue<Button> hs4Queue = new Queue<Button>();

        // Omonatlar
        Queue<Button> d1Queue = new Queue<Button>();
        Queue<Button> d2Queue = new Queue<Button>();
        Queue<Button> d3Queue = new Queue<Button>();
        Queue<Button> d4Queue = new Queue<Button>();

        public MainPage()
        {
            InitializeComponent();
        }
        public void OnCreateCustomerClicked(object sender, EventArgs e)
        {
            Random rand = new Random();
            string name = families[rand.Next(families.Length)];
            string id = Convert.ToString(1000);

        }
        public void ServeToSC(object sender, EventArgs e)
        {
            int a = 7;
        }
        public void ServeToE(object sender, EventArgs e)
        {
            int a = 7;
        }
        public void ServeToHS(object sender, EventArgs e)
        {
            int a = 7;
        }
        public void ServeToD(object sender, EventArgs e)
        {
            int a = 7;
        }
    }
}
