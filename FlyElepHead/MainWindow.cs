using info = FlyElepHead.GlobalInfo;

#pragma warning disable IDE0079 // 请删除不必要的忽略
#pragma warning disable CS8602 // 解引用可能出现空引用。

namespace FlyElepHead
{
    public partial class MainWindow : Form
    {
        readonly Dictionary<string, Panel> scenes = new();
        readonly Dictionary<string, Control> controllib = new(); 

        public MainWindow()
        {
            InitializeComponent();

            InitForm();

            Panel start_panel = new();
            scenes.Add("StartPanel", start_panel);
            Panel game_panel = new();
            scenes.Add("GamePanel", game_panel);
            Panel end_panel = new();
            scenes.Add("EndPanel", end_panel);

            InitPanel("StartPanel");

            scenes["StartPanel"].Parent = this;

            (controllib["StartPanel_Button_StartGame"] as Button).Click += (_, _) =>
            {
                scenes["StartPanel"].Parent = null;

                scenes["GamePanel"].Parent = this;

                InitPanel("GamePanel");
            };

        }

        private void InitForm()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void InitPanel(string name)
        {
            switch (name)
            {
                case "StartPanel":
                    Panel panel = scenes[name];
                    panel.Dock = DockStyle.Fill;
                    Label label = new()
                    {
                        Text = info.start_panel_title,
                        Parent = panel,
                        Size = new Size()
                        {
                            Width = info.menu_label_title_width,
                            Height = info.menu_label_title_height
                        },
                        Font = new Font("Consolas", info.menu_label_title_fontsize)
                    };
                    label.Location = new Point()
                    {
                        X = (Width - label.PreferredSize.Width) / 2,
                        Y = (Height - label.PreferredSize.Height) / 2 - info.menu_label_title_vertical_offset
                    };
                    Button button = new()
                    {
                        Text = "开始游戏",
                        Size = new Size()
                        {
                            Width = info.menu_btn_width,
                            Height = info.menu_btn_height
                        },
                        Location = new Point()
                        {
                            X = (Width - info.menu_btn_width) / 2,
                            Y = (Height - info.menu_btn_height) / 2 + 100
                        },
                        Parent = panel,
                    };
                    controllib.Add("StartPanel_Label_Title", label);
                    controllib.Add("StartPanel_Button_StartGame", button);

                    break;
                case "GamePanel":
                    Panel game_panel =scenes[name];
                    game_panel.Dock = DockStyle.Fill;


                    Label Startlabel = new()
                    {
                        Text = info.game_panel_title,
                        Parent = game_panel,
                        Size = new Size()
                        {
                            Height = info.menu_label_title_height,
                            Width = info.menu_label_title_width
                        },
                        Font = new Font("Consolas", info.menu_label_title_fontsize)
                    };
                    Startlabel.Location = new Point()
                    {
                        X = (Width - Startlabel.PreferredSize.Width) / 2,
                        Y = (Height - Startlabel.PreferredSize.Height) / 2 - info.menu_label_title_vertical_offset
                    };

                    break;
            }
        }
    }
}

#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore IDE0079 // 请删除不必要的忽略