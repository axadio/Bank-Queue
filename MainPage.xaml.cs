using System.Collections.Generic;
using System.Linq;
#nullable enable annotations
#nullable enable

namespace Bank_Queue
{
    public partial class MainPage : ContentPage
    {
        public bool servingToSC1 = false;
        public bool servingToSC2 = false;
        public bool servingToSC3 = false;
        public bool servingToSC4 = false;
        public bool servingToE1 = false;
        public bool servingToE2 = false;
        public bool servingToE3 = false;
        public bool servingToE4 = false;
        public bool servingToHS1 = false;
        public bool servingToHS2 = false;
        public bool servingToHS3 = false;
        public bool servingToHS4 = false;
        public bool servingToD1 = false;
        public bool servingToD2 = false;
        public bool servingToD3 = false;
        public bool servingToD4 = false;

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
            StatusLabel.Text = "Xizmat ko'rsatish axboroti: \n";
        }
        public void OnCreateCustomerClicked(object sender, EventArgs e)
        {
            Random rand = new Random();
            string name = families[rand.Next(families.Length)];
            string id = "";
            string department = "";
            Button customer;

            int b = rand.Next(1, 5); // 1 to 4: tanlangan bo‘lim
            int minCount = int.MaxValue;
            int selectedSub = 1;

            switch (b)
            {
                case 1: // Sotuv va kredit
                    int[] scCounts = { sc1Queue.Count, sc2Queue.Count, sc3Queue.Count, sc4Queue.Count };
                    for (int i = 0; i < 4; i++)
                    {
                        if (scCounts[i] < minCount)
                        {
                            minCount = scCounts[i];
                            selectedSub = i + 1;
                        }
                    }

                    switch (selectedSub)
                    {
                        case 1:
                            id = sc1id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            sc1Queue.Enqueue(customer);
                            SC1layout.Children.Add(customer);
                            department = "SC1";
                            break;
                        case 2:
                            id = sc2id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            sc2Queue.Enqueue(customer);
                            SC2layout.Children.Add(customer);
                            department = "SC2";
                            break;
                        case 3:
                            id = sc3id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            sc3Queue.Enqueue(customer);
                            SC3layout.Children.Add(customer);
                            department = "SC3";
                            break;
                        case 4:
                            id = sc4id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            sc4Queue.Enqueue(customer);
                            SC4layout.Children.Add(customer);
                            department = "SC4";
                            break;
                    }
                    break;

                case 2: // Ayirboshlash
                    int[] eCounts = { e1Queue.Count, e2Queue.Count, e3Queue.Count, e4Queue.Count };
                    for (int i = 0; i < 4; i++)
                    {
                        if (eCounts[i] < minCount)
                        {
                            minCount = eCounts[i];
                            selectedSub = i + 1;
                        }
                    }

                    switch (selectedSub)
                    {
                        case 1:
                            id = e1id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            e1Queue.Enqueue(customer);
                            E1layout.Children.Add(customer);
                            department = "E1";
                            break;
                        case 2:
                            id = e2id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            e2Queue.Enqueue(customer);
                            E2layout.Children.Add(customer);
                            department = "E2";
                            break;
                        case 3:
                            id = e3id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            e3Queue.Enqueue(customer);
                            E3layout.Children.Add(customer);
                            department = "E3";
                            break;
                        case 4:
                            id = e4id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            e4Queue.Enqueue(customer);
                            E4layout.Children.Add(customer);
                            department = "E4";
                            break;
                    }
                    break;

                case 3: // Qo‘llab-quvvatlash
                    int[] hsCounts = { hs1Queue.Count, hs2Queue.Count, hs3Queue.Count, hs4Queue.Count };
                    for (int i = 0; i < 4; i++)
                    {
                        if (hsCounts[i] < minCount)
                        {
                            minCount = hsCounts[i];
                            selectedSub = i + 1;
                        }
                    }

                    switch (selectedSub)
                    {
                        case 1:
                            id = hs1id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            hs1Queue.Enqueue(customer);
                            HS1layout.Children.Add(customer);
                            department = "HS1";
                            break;
                        case 2:
                            id = hs2id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            hs2Queue.Enqueue(customer);
                            HS2layout.Children.Add(customer);
                            department = "HS2";
                            break;
                        case 3:
                            id = hs3id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            hs3Queue.Enqueue(customer);
                            HS3layout.Children.Add(customer);
                            department = "HS3";
                            break;
                        case 4:
                            id = hs4id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            hs4Queue.Enqueue(customer);
                            HS4layout.Children.Add(customer);
                            department = "HS4";
                            break;
                    }
                    break;

                case 4: // Omonatlar
                    int[] dCounts = { d1Queue.Count, d2Queue.Count, d3Queue.Count, d4Queue.Count };
                    for (int i = 0; i < 4; i++)
                    {
                        if (dCounts[i] < minCount)
                        {
                            minCount = dCounts[i];
                            selectedSub = i + 1;
                        }
                    }

                    switch (selectedSub)
                    {
                        case 1:
                            id = d1id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            d1Queue.Enqueue(customer);
                            D1layout.Children.Add(customer);
                            department = "D1";
                            break;
                        case 2:
                            id = d2id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            d2Queue.Enqueue(customer);
                            D2layout.Children.Add(customer);
                            department = "D2";
                            break;
                        case 3:
                            id = d3id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            d3Queue.Enqueue(customer);
                            D3layout.Children.Add(customer);
                            department = "D3";
                            break;
                        case 4:
                            id = d4id++.ToString();
                            customer = CreateCustomerButton(name, id);
                            d4Queue.Enqueue(customer);
                            D4layout.Children.Add(customer);
                            department = "D4";
                            break;
                    }
                    break;
            }

            // Statusga yozuv qo‘shish
            if (department != "")
            {
                StatusLabel.Text += $"Mijoz yaratildi: {name} (id:{id}) — {department}\n";
            }
        }


        private Button CreateCustomerButton(string name, string id)
        {
            Button button = new Button
            {
                Text = $"{name} ({id})",
                FontSize = 14,
                BackgroundColor = Colors.LightGray,
                Margin = new Thickness(5)
            };
            button.Clicked += Selected;
            return button;
        }
        public delegate void EventHandler(object sender, EventArgs e);
        public void Selected(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var parent = clickedButton.Parent;
            string p = "";
            if (parent == SC1layout)
            {
                if (sc1Queue.Count > 0 && !servingToSC1)
                {
                    servingToSC1 = true;
                    Button FE = sc1Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(sc1Queue);
                    sc1Queue.Clear();
                    sc1Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        sc1Queue.Enqueue(elem);
                    }
                }
                p = "SC1";
            }
            else if (parent == SC2layout)
            {
                if (sc2Queue.Count > 0 && !servingToSC2)
                {
                    servingToSC2 = true;
                    Button FE = sc2Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(sc2Queue);
                    sc2Queue.Clear();
                    sc2Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        sc2Queue.Enqueue(elem);
                    }
                }
                p = "SC2";
            }
            else if (parent == SC3layout)
            {
                if (sc3Queue.Count > 0 && !servingToSC3)
                {
                    servingToSC3 = true;
                    Button FE = sc3Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(sc3Queue);
                    sc3Queue.Clear();
                    sc3Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        sc3Queue.Enqueue(elem);
                    }
                }
                p = "SC3";
            }
            else if (parent == SC4layout)
            {
                if (sc4Queue.Count > 0 && !servingToSC4)
                {
                    servingToSC4 = true;
                    Button FE = sc4Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(sc4Queue);
                    sc4Queue.Clear();
                    sc4Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        sc4Queue.Enqueue(elem);
                    }
                }
                p = "SC4";
            }
            else if (parent == E1layout)
            {
                if (e1Queue.Count > 0 && !servingToE1)
                {
                    servingToE1 = true;
                    Button FE = e1Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(e1Queue);
                    e1Queue.Clear();
                    e1Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        e1Queue.Enqueue(elem);
                    }
                }
                p = "E1";
            }
            else if (parent == E2layout)
            {
                if (e2Queue.Count > 0 && !servingToE2)
                {
                    servingToE2 = true;
                    Button FE = e2Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(e2Queue);
                    e2Queue.Clear();
                    e2Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        e2Queue.Enqueue(elem);
                    }
                }
                p = "E2";
            }
            else if (parent == E3layout)
            {
                if (e3Queue.Count > 0 && !servingToE3)
                {
                    servingToE3 = true;
                    Button FE = e3Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(e3Queue);
                    e3Queue.Clear();
                    e3Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        e3Queue.Enqueue(elem);
                    }
                }
                p = "E3";
            }
            else if (parent == E4layout)
            {
                if (e4Queue.Count > 0 && !servingToE4)
                {
                    servingToE4 = true;
                    Button FE = e4Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(e4Queue);
                    e4Queue.Clear();
                    e4Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        e4Queue.Enqueue(elem);
                    }
                }
                p = "E4";
            }
            else if (parent == HS1layout)
            {
                if (hs1Queue.Count > 0 && !servingToHS1)
                {
                    servingToHS1 = true;
                    Button FE = hs1Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(hs1Queue);
                    hs1Queue.Clear();
                    hs1Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        hs1Queue.Enqueue(elem);
                    }
                }
                p = "HS1";
            }
            else if (parent == HS2layout)
            {
                if (hs2Queue.Count > 0 && !servingToHS2)
                {
                    servingToHS2 = true;
                    Button FE = hs2Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(hs2Queue);
                    hs2Queue.Clear();
                    hs2Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        hs2Queue.Enqueue(elem);
                    }
                }
                p = "HS2";
            }
            else if (parent == HS3layout)
            {
                if (hs3Queue.Count > 0 && !servingToHS3)
                {
                    servingToHS3 = true;
                    Button FE = hs3Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(hs3Queue);
                    hs3Queue.Clear();
                    hs3Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        hs3Queue.Enqueue(elem);
                    }
                }
                p = "HS3";
            }
            else if (parent == HS4layout)
            {
                if (hs4Queue.Count > 0 && !servingToHS4)
                {
                    servingToHS4 = true;
                    Button FE = hs4Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(hs4Queue);
                    hs4Queue.Clear();
                    hs4Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        hs4Queue.Enqueue(elem);
                    }
                }
                p = "HS4";
            }
            else if (parent == D1layout)
            {
                if (d1Queue.Count > 0 && !servingToD1)
                {
                    servingToD1 = true;
                    Button FE = d1Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(d1Queue);
                    d1Queue.Clear();
                    d1Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        d1Queue.Enqueue(elem);
                    }
                }
                p = "D1";
            }
            else if (parent == D2layout)
            {
                if (d2Queue.Count > 0 && !servingToD2)
                {
                    servingToD2 = true;
                    Button FE = d2Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(d2Queue);
                    d2Queue.Clear();
                    d2Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        d2Queue.Enqueue(elem);
                    }
                }
                p = "D2";
            }
            else if (parent == D3layout)
            {
                if (d3Queue.Count > 0 && !servingToD3)
                {
                    servingToD3 = true;
                    Button FE = d3Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(d3Queue);
                    d3Queue.Clear();
                    d3Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        d3Queue.Enqueue(elem);
                    }
                }
                p = "D3";
            }
            else if (parent == D4layout)
            {
                if (d4Queue.Count > 0 && !servingToD4)
                {
                    servingToD4 = true;
                    Button FE = d4Queue.Dequeue();
                    FE.BackgroundColor = Colors.Purple;
                    Queue<Button> RQ = new Queue<Button>(d4Queue);
                    d4Queue.Clear();
                    d4Queue.Enqueue(FE);
                    foreach (var elem in RQ)
                    {
                        d4Queue.Enqueue(elem);
                    }
                }
                p = "D4";
            }

            DisplayAlert("Xizmat ko'rsatilmoqda...", $" bo'lim {p}", "Yopish");
        }

        public void ServeToSC(object sender, EventArgs e)
        {
            // SC1, SC2, SC3, SC4 navbatlari uchun label'lar
            Label sc1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC1 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC2 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC3 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            // SC1 navbatni tekshirish
            if (sc1Queue.Count > 0 && servingToSC1)
            {
                var served = sc1Queue.Dequeue(); // navbatdagini olib tashlayapmiz
                SC1layout.Children.Clear();             // Layoutni tozalash
                SC1layout.Children.Add(sc1Label);       // Labelni qo‘shish
                foreach (var btn in sc1Queue) SC1layout.Children.Add(btn);
                servingToSC1 = false;
            }


            // SC2, SC3, SC4 navbatlari uchun aynan shu tarzda ishlash
            if (sc2Queue.Count > 0 && servingToSC2)
            {
                var served = sc2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                SC2layout.Children.Clear();
                SC2layout.Children.Add(sc2Label);
                foreach (var btn in sc2Queue) SC2layout.Add(btn);
                servingToSC2 = false;
            }

            if (sc3Queue.Count > 0 && servingToSC3)
            {
                var served = sc3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                SC3layout.Children.Clear();
                SC3layout.Children.Add(sc3Label);
                foreach (var btn in sc3Queue) SC3layout.Children.Add(btn);
                servingToSC3 = false;
            }

            if (sc4Queue.Count > 0 && servingToSC4)
            {
                var served = sc4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                SC4layout.Children.Clear();
                SC4layout.Children.Add(sc4Label);
                foreach (var btn in sc4Queue) SC4layout.Children.Add(btn);
                servingToSC4 = false;
            }

            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }


        public void ServeToE(object sender, EventArgs e)
        {
            // E1, E2, E3, E4 navbatlari uchun label'lar
            Label e1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E1 navbat", VerticalOptions = LayoutOptions.Start };
            Label e2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E2 navbat", VerticalOptions = LayoutOptions.Start };
            Label e3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E3 navbat", VerticalOptions = LayoutOptions.Start };
            Label e4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            // E1 navbatni tekshirish
            if (e1Queue.Count > 0 && servingToE1)
            {
                var served = e1Queue.Dequeue(); // navbatdagini olib tashlayapmiz
                E1layout.Children.Clear();             // Layoutni tozalash
                E1layout.Children.Add(e1Label);       // Labelni qo‘shish
                foreach (var btn in e1Queue) E1layout.Children.Add(btn);
                servingToE1 = false;
            }

            // E2 navbatini tekshirish
            if (e2Queue.Count > 0 && servingToE2)
            {
                var served = e2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                E2layout.Children.Clear();
                E2layout.Children.Add(e2Label);
                foreach (var btn in e2Queue) E2layout.Add(btn);
                servingToE2 = false;
            }

            // E3 navbatini tekshirish
            if (e3Queue.Count > 0 && servingToE3)
            {
                var served = e3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                E3layout.Children.Clear();
                E3layout.Children.Add(e3Label);
                foreach (var btn in e3Queue) E3layout.Children.Add(btn);
                servingToE3 = false;
            }

            // E4 navbatini tekshirish
            if (e4Queue.Count > 0 && servingToE4)
            {
                var served = e4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                E4layout.Children.Clear();
                E4layout.Children.Add(e4Label);
                foreach (var btn in e4Queue) E4layout.Children.Add(btn);
                servingToE4 = false;
            }

            // Xizmat ko‘rsatish xabarlarini chiqarish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }


        public void ServeToHS(object sender, EventArgs e)
        {
            // HS1, HS2, HS3, HS4 navbatlari uchun label'lar
            Label hs1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS1 navbat", VerticalOptions = LayoutOptions.Start };
            Label hs2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS2 navbat", VerticalOptions = LayoutOptions.Start };
            Label hs3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS3 navbat", VerticalOptions = LayoutOptions.Start };
            Label hs4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            // HS1 navbatni tekshirish
            if (hs1Queue.Count > 0 && servingToHS1)
            {
                var served = hs1Queue.Dequeue(); // navbatdagini olib tashlayapmiz
                HS1layout.Children.Clear();             // Layoutni tozalash
                HS1layout.Children.Add(hs1Label);       // Labelni qo‘shish
                foreach (var btn in hs1Queue) HS1layout.Children.Add(btn);
                servingToHS1 = false;
            }

            // HS2 navbatini tekshirish
            if (hs2Queue.Count > 0 && servingToHS2)
            {
                var served = hs2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                HS2layout.Children.Clear();
                HS2layout.Children.Add(hs2Label);
                foreach (var btn in hs2Queue) HS2layout.Add(btn);
                servingToHS2 = false;
            }

            // HS3 navbatini tekshirish
            if (hs3Queue.Count > 0 && servingToHS3)
            {
                var served = hs3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                HS3layout.Children.Clear();
                HS3layout.Children.Add(hs3Label);
                foreach (var btn in hs3Queue) HS3layout.Children.Add(btn);
                servingToHS3 = false;
            }

            // HS4 navbatini tekshirish
            if (hs4Queue.Count > 0 && servingToHS4)
            {
                var served = hs4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                HS4layout.Children.Clear();
                HS4layout.Children.Add(hs4Label);
                foreach (var btn in hs4Queue) HS4layout.Children.Add(btn);
                servingToHS4 = false;
            }

            // Xizmat ko‘rsatish xabarlarini chiqarish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }


        public void ServeToD(object sender, EventArgs e)
        {
            // D1, D2, D3, D4 navbatlari uchun label'lar
            Label d1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D1 navbat", VerticalOptions = LayoutOptions.Start };
            Label d2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D2 navbat", VerticalOptions = LayoutOptions.Start };
            Label d3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D3 navbat", VerticalOptions = LayoutOptions.Start };
            Label d4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            // D1 navbatni tekshirish
            if (d1Queue.Count > 0 && servingToD1)
            {
                var served = d1Queue.Dequeue(); // navbatdagini olib tashlayapmiz
                D1layout.Children.Clear();             // Layoutni tozalash
                D1layout.Children.Add(d1Label);       // Labelni qo‘shish
                foreach (var btn in d1Queue) D1layout.Children.Add(btn);
                servingToD1 = false;
            }

            // D2 navbatini tekshirish
            if (d2Queue.Count > 0 && servingToD2)
            {
                var served = d2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                D2layout.Children.Clear();
                D2layout.Children.Add(d2Label);
                foreach (var btn in d2Queue) D2layout.Add(btn);
                servingToD2 = false;
            }

            // D3 navbatini tekshirish
            if (d3Queue.Count > 0 && servingToD3)
            {
                var served = d3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                D3layout.Children.Clear();
                D3layout.Children.Add(d3Label);
                foreach (var btn in d3Queue) D3layout.Children.Add(btn);
                servingToD3 = false;
            }

            // D4 navbatini tekshirish
            if (d4Queue.Count > 0 && servingToD4)
            {
                var served = d4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
                D4layout.Children.Clear();
                D4layout.Children.Add(d4Label);
                foreach (var btn in d4Queue) D4layout.Children.Add(btn);
                servingToD4 = false;
            }

            // Xizmat ko‘rsatish xabarlarini chiqarish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }

    }
}
