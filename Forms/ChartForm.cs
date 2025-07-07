public class ChartForm : Form
{
    async Task<List<Item>> LoadData()
    {
        // agrupar por produto

        return [
            new Item("bico", 2),
            new Item("injetor", 6)
        ];
    }

    public ChartForm()
    {
        Width = 800;
        Height = 800;

        List<Item> items = [];
        Load += async (o, e) => items = await LoadData();

        var pb = new PictureBox {
            Dock = DockStyle.Fill
        };

        var font = new Font(FontFamily.GenericMonospace, 12f);

        pb.Paint += (o, e) =>
        {
            var g = e.Graphics;
            var sum = items.Sum(t => t.quantidade);
            int seed = 40;
            var brushes = items.ToDictionary(
                t => t.produto,
                t => new SolidBrush(GetRandomColor(++seed))
            );
            var rect = e.ClipRectangle;

            float size = .8f * rect.Height;
            float cx = rect.Width / 2;
            float cy = rect.Height / 2;
            var pieRect = new RectangleF(
                cx - size / 2,
                cy - size / 2,
                size, size
            );

            float angle = 0f;
            int i = 0;
            foreach (var (x, y) in items)
            {
                var pieAngle = 360f * y / sum;
                g.FillPie(brushes[x], pieRect, angle, pieAngle);
                angle += pieAngle;

                g.FillRectangle(brushes[x], 20, 20 + i * 20, 20, 20);
                g.DrawString(x, font, Brushes.Black, 20 + 20, 20 + i * 20);
                i++;
            }

            pb.Invalidate();
        };

        Controls.Add(pb);
        Color GetRandomColor(int seed)
        {
            var rand = new Random(seed);
            return Color.FromArgb(255,
                rand.Next(255),
                rand.Next(255),
                rand.Next(255)
            );
        }
    }
}

record Item(string produto, int quantidade);