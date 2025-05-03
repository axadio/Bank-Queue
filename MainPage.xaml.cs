using System.Collections.Generic;
using System.Linq;

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
            return new Button
            {
                Text = $"{name} ({id})",
                FontSize = 14,
                BackgroundColor = Colors.LightGray,
                Margin = new Thickness(5)
            };
        }

        public void ServeToSC(object sender, EventArgs e)
        {
            Label sc1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC1 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC2 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC3 navbat", VerticalOptions = LayoutOptions.Start };
            Label sc4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "SC4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            if (sc1Queue.Count > 0)
            {
                var served = sc1Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }
            if (sc2Queue.Count > 0)
            {
                var served = sc2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }
            if (sc3Queue.Count > 0)
            {
                var served = sc3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }
            if (sc4Queue.Count > 0)
            {
                var served = sc4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            // Layout tozalash
            SC1layout.Children.Clear();
            SC2layout.Children.Clear();
            SC3layout.Children.Clear();
            SC4layout.Children.Clear();

            SC1layout.Children.Add(sc1Label);
            SC2layout.Children.Add(sc2Label);
            SC3layout.Children.Add(sc3Label);
            SC4layout.Children.Add(sc4Label);

            foreach (var btn in sc1Queue) SC1layout.Children.Add(btn);
            foreach (var btn in sc2Queue) SC2layout.Children.Add(btn);
            foreach (var btn in sc3Queue) SC3layout.Children.Add(btn);
            foreach (var btn in sc4Queue) SC4layout.Children.Add(btn);

            // StatusLabel yangilash
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }

        public void ServeToE(object sender, EventArgs e)
        {
            Label e1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E1 navbat", VerticalOptions = LayoutOptions.Start };
            Label e2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E2 navbat", VerticalOptions = LayoutOptions.Start };
            Label e3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E3 navbat", VerticalOptions = LayoutOptions.Start };
            Label e4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "E4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            if (e1Queue.Count > 0)
            {
                var served = e1Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (e2Queue.Count > 0)
            {
                var served = e2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (e3Queue.Count > 0)
            {
                var served = e3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (e4Queue.Count > 0)
            {
                var served = e4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            E1layout.Children.Clear();
            E2layout.Children.Clear();
            E3layout.Children.Clear();
            E4layout.Children.Clear();

            E1layout.Children.Add(e1Label);
            E2layout.Children.Add(e2Label);
            E3layout.Children.Add(e3Label);
            E4layout.Children.Add(e4Label);

            foreach (var btn in e1Queue) E1layout.Children.Add(btn);
            foreach (var btn in e2Queue) E2layout.Children.Add(btn);
            foreach (var btn in e3Queue) E3layout.Children.Add(btn);
            foreach (var btn in e4Queue) E4layout.Children.Add(btn);

            // StatusLabel ga xizmat ko‘rsatilganlar haqida yozish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }

        public void ServeToHS(object sender, EventArgs e)
        {
            Label HS1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS1 navbat", VerticalOptions = LayoutOptions.Start };
            Label HS2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS2 navbat", VerticalOptions = LayoutOptions.Start };
            Label HS3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS3 navbat", VerticalOptions = LayoutOptions.Start };
            Label HS4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "HS4 navbat", VerticalOptions = LayoutOptions.Start };

            List<string> servedMessages = new();

            if (hs1Queue.Count > 0)
            {
                var served = hs1Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (hs2Queue.Count > 0)
            {
                var served = hs2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (hs3Queue.Count > 0)
            {
                var served = hs3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (hs4Queue.Count > 0)
            {
                var served = hs4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            HS1layout.Children.Clear();
            HS2layout.Children.Clear();
            HS3layout.Children.Clear();
            HS4layout.Children.Clear();

            HS1layout.Children.Add(HS1Label);
            HS2layout.Children.Add(HS2Label);
            HS3layout.Children.Add(HS3Label);
            HS4layout.Children.Add(HS4Label);

            foreach (var btn in hs1Queue) HS1layout.Children.Add(btn);
            foreach (var btn in hs2Queue) HS2layout.Children.Add(btn);
            foreach (var btn in hs3Queue) HS3layout.Children.Add(btn);
            foreach (var btn in hs4Queue) HS4layout.Children.Add(btn);

            // StatusLabel ga xizmat ko‘rsatilganlar haqida yozish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }

        public void ServeToD(object sender, EventArgs e)
        {
            // Har bir bo‘lim uchun sarlavha
            Label D1Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D1 navbat", VerticalOptions = LayoutOptions.Start };
            Label D2Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D2 navbat", VerticalOptions = LayoutOptions.Start };
            Label D3Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D3 navbat", VerticalOptions = LayoutOptions.Start };
            Label D4Label = new Label { BackgroundColor = Colors.LightSalmon, Text = "D4 navbat", VerticalOptions = LayoutOptions.Start };

            // Status matnini yig‘ish uchun list
            List<string> servedMessages = new();

            // Har bir bo‘limdan mijozni chaqirish va statusga yozish
            if (d1Queue.Count > 0)
            {
                var served = d1Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (d2Queue.Count > 0)
            {
                var served = d2Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (d3Queue.Count > 0)
            {
                var served = d3Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            if (d4Queue.Count > 0)
            {
                var served = d4Queue.Dequeue();
                servedMessages.Add($"Mijoz {served.Text}ga xizmat ko‘rsatildi.");
            }

            // Layoutlarni tozalab, sarlavhalarni qayta qo‘shish
            D1layout.Children.Clear();
            D2layout.Children.Clear();
            D3layout.Children.Clear();
            D4layout.Children.Clear();

            D1layout.Children.Add(D1Label);
            D2layout.Children.Add(D2Label);
            D3layout.Children.Add(D3Label);
            D4layout.Children.Add(D4Label);

            foreach (var btn in d1Queue) D1layout.Children.Add(btn);
            foreach (var btn in d2Queue) D2layout.Children.Add(btn);
            foreach (var btn in d3Queue) D3layout.Children.Add(btn);
            foreach (var btn in d4Queue) D4layout.Children.Add(btn);

            // StatusLabelga xabarlarni qo‘shish
            foreach (var msg in servedMessages)
            {
                StatusLabel.Text += msg + "\n";
            }
        }
    }
}
