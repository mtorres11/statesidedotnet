using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StatesideJokes.Models;
using StatesideJokes.Parser;
using static System.Net.Mime.MediaTypeNames;

namespace StatesideJokesApp
{
    public class GUIApp : Form
    {
        private Button fetchJokeButton;
        private Label randomJokeLabel;
        private Label jokeCountLabel;
        private DadJokesAsync dadJokesAsync;

        public GUIApp()
        {
            InitializeComponent();

            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<GUIApp>>();
            var jsonParser = new JSONParser(serviceProvider.GetRequiredService<ILogger<JSONParser>>());
            dadJokesAsync = new DadJokesAsync(serviceProvider.GetRequiredService<ILogger<DadJokesAsync>>(), jsonParser);

            fetchJokeButton.Click += async (sender, e) =>
            {
                try
                {
                    int jokeCount = await dadJokesAsync.GetJokeCount();
                    jokeCountLabel.Text = "Total dad jokes in the world: " + jokeCount;
                    string randomJoke = await dadJokesAsync.GetRandomJoke();
                    randomJokeLabel.Text = "Random Joke: " + randomJoke;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            };
        }

        private void InitializeComponent()
        {
            fetchJokeButton = new Button();
            randomJokeLabel = new Label();
            jokeCountLabel = new Label();
            SuspendLayout();
            // 
            // fetchJokeButton
            // 
            fetchJokeButton.Location = new Point(234, 226);
            fetchJokeButton.Name = "fetchJokeButton";
            fetchJokeButton.Size = new Size(164, 23);
            fetchJokeButton.TabIndex = 0;
            fetchJokeButton.Text = "Get Random Joke";
            // 
            // randomJokeLabel
            // 
            randomJokeLabel.AutoSize = true;
            randomJokeLabel.Location = new Point(12, 34);
            randomJokeLabel.Name = "randomJokeLabel";
            randomJokeLabel.Size = new Size(164, 15);
            randomJokeLabel.TabIndex = 1;
            randomJokeLabel.Text = "Random Joke: ";
            // 
            // jokeCountLabel
            // 
            jokeCountLabel.AutoSize = true;
            jokeCountLabel.Location = new Point(12, 9);
            jokeCountLabel.Name = "jokeCountLabel";
            jokeCountLabel.Size = new Size(163, 15);
            jokeCountLabel.TabIndex = 2;
            jokeCountLabel.Text = "Total dad jokes in the world: 0";
            // 
            // GUIApp
            // 
            ClientSize = new Size(630, 261);
            Controls.Add(jokeCountLabel);
            Controls.Add(fetchJokeButton);
            Controls.Add(randomJokeLabel);
            Name = "GUIApp";
            Text = "Dad Jokes App";
            ResumeLayout(false);
            PerformLayout();
        }

        /*[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUIApp());
        }*/
    }
}
