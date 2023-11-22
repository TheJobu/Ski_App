using MaterialSkin;
using MaterialSkin.Controls;

namespace FLA5_SkiApp
{
    public partial class Form1 : MaterialForm
    {
        Dictionary<string, decimal> itemPrices = new Dictionary<string, decimal>();

        public Form1()
        {
            InitializeComponent();
            var skin = MaterialSkinManager.Instance;
            skin.AddFormToManage(this);
            skin.Theme = MaterialSkinManager.Themes.DARK;
            skin.ColorScheme = new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red500,
                Accent.Red200,
                TextShade.WHITE);

            PopulateItemPrices();
        }

        private void PopulateItemPrices()
        {
            itemPrices.Add("Atomic Vantage 79 C Skis: $299.99", 299.99M);
            itemPrices.Add("K2 Press Skis: $399.95", 399.95M);
            itemPrices.Add("Salomon QST 85 Skis: $399.99", 399.99M);
            itemPrices.Add("Volkl Deacon 74 Skis: $499.00", 499.00M);
            itemPrices.Add("Marker Griffon 13 ID Ski Bindings: $229.95", 229.95M);
            itemPrices.Add("Salomon STH2 WTR 13 Ski Bindings: $249.95", 249.95M);
            itemPrices.Add("Atomic Warden MNC 13 Ski Bindings: $259.99", 259.99M);
            itemPrices.Add("Look Pivot 14 AW Ski Bindings: $329.95", 329.95M);
            itemPrices.Add("Rossignol Tactic Ski Poles: $49.95", 49.95M);
            itemPrices.Add("Black Diamond Traverse Ski Poles: $79.95", 79.95M);
            itemPrices.Add("Scott Team Issue Ski Poles: $89.95", 89.95M);
            itemPrices.Add("LEKI Stealth S Ski Poles: $99.95", 99.95M);
            itemPrices.Add("Dalbello DS MX 100 Ski Boots: $299.95", 299.95M);
            itemPrices.Add("Atomic Hawx Prime 100 Ski Boots: $399.99", 399.99M);
            itemPrices.Add("Salomon S/Pro 100 Ski Boots: $499.95", 499.95M);
            itemPrices.Add("Nordica Speedmachine 110 Ski Boots: $499.99", 499.99M);
            itemPrices.Add("The North Face Carto Triclimate Jacket: $239.95", 239.95M);
            itemPrices.Add("Patagonia Insulated Snowbelle Pants: $199.00", 199.00M);
            itemPrices.Add("Hestra Army Leather Heli Ski Gloves: $160.00", 160.00M);
            itemPrices.Add("Patagonia Fisherman's Rolled Beanie: $39.00", 39.00M);
            itemPrices.Add("Osprey Kamber 22 Backpack: $150.00", 150.00M);
            itemPrices.Add("HotHands Hand Warmers (10 pairs): $9.99", 9.99M);
            itemPrices.Add("Toko NF Hot Box Wax: $24.95", 24.95M);
            itemPrices.Add("Peet Advantage Boot Dryer: $99.99", 99.99M);
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 6)
            {
                clearOptions();
            }

            if (materialTabControl1.SelectedIndex == 7)
            {
                List<string> checkedItems = new List<string>();
                decimal totalPrice = 0;

                for (int i = 0; i < materialTabControl1.TabPages.Count; i++)
                {
                    if (i == 7)
                        continue;

                    foreach (Control control in materialTabControl1.TabPages[i].Controls)
                    {
                        if (control is MaterialSkin.Controls.MaterialCard card)
                        {
                            foreach (Control cardControl in card.Controls)
                            {
                                if (cardControl is MaterialSkin.Controls.MaterialCheckbox checkBox && checkBox.Checked)
                                {
                                    checkedItems.Add(checkBox.Text);
                                    if (itemPrices.ContainsKey(checkBox.Text))
                                        totalPrice += itemPrices[checkBox.Text];
                                }
                            }
                        }
                    }
                }

                string message;
                if (checkedItems.Count > 0)
                {
                    message = "".PadLeft(26) + "Checked Items:\n\n----------------------------------------------------------------\n\n" + string.Join("\n", checkedItems);
                    message += $"\n\n----------------------------------------------------------------\n\n"+"".PadLeft(23) + $"Total Price: {totalPrice:C}";
                    MessageBox.Show(message, "Checked Items and Total Price", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearOptions();
                }
                else
                    MessageBox.Show("No items are checked.", "Checked Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (materialTabControl1.SelectedIndex == 8)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Application.Exit();
            }
        }

        private void clearOptions()
        {
            for (int i = 0; i < materialTabControl1.TabPages.Count; i++)
            {
                if (i == 6)
                    continue;

                foreach (Control control in materialTabControl1.TabPages[i].Controls)
                {
                    if (control is MaterialSkin.Controls.MaterialCard card)
                    {
                        foreach (Control cardControl in card.Controls)
                        {
                            if (cardControl is MaterialSkin.Controls.MaterialCheckbox checkBox)
                                checkBox.Checked = false;
                        }
                    }
                }
            }
        }
    }
}
