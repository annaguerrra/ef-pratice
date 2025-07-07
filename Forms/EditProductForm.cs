using System.ComponentModel;
using System.Data.Common;


public class EditProductForm : Form
{
    async Task Save()
    {
        DialogResult = DialogResult.OK;

        int id = ProductId;
        string name = Name;
        decimal price = Price;
        // TO DO
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int ProductId
    {
        get => int.Parse(tbId.Text);
        set => tbId.Text = value.ToString();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Name
    {
        get => tbName.Text;
        set => tbName.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public decimal Price
    {
        get => decimal.Parse(tbPrice.Text);
        set => tbPrice.Text = value.ToString();
    }

    private TextBox tbId;
    private TextBox tbName;
    private TextBox tbPrice;

    public EditProductForm()
    {
        tbId = new TextBox { ReadOnly = true, Width = 200 };
        tbName = new TextBox { Width = 200 };
        tbPrice = new TextBox { Width = 200 };
        Width = 400;
        Height = 400;
        Text = "Editar Produto";
        var btSave = new Button
        {
            Text = "Salvar",
            Height = 40,
            Width = 80
        };
        var btExit = new Button
        {
            Text = "Cancelar",
            Height = 40,
            Width = 80
        };

        btExit.Click += (o, e) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        btSave.Click += async (o, e) => await Save();

        var layout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20),
            Controls = {
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "Id",
                        },
                        tbId
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "Nome",
                        },
                        tbName
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.LeftToRight,
                    Width = 400, Height = 40,
                    Controls = {
                        new Label {
                            Text = "Preço",
                        },
                        tbPrice
                    }
                },
                new FlowLayoutPanel {
                    FlowDirection = FlowDirection.RightToLeft,
                    Width = 300, Height = 120,
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Controls = {
                        btSave, btExit
                    }
                }
            }
        };

        Controls.AddRange(layout);
    }
}