
namespace Lab2Solution
{

    public partial class MainPage : ContentPage
    {
        bool sortByClue = true;
        public MainPage()
        {
            InitializeComponent();
            EntriesLV.ItemsSource = MauiProgram.ibl.GetEntries((sortByClue ? "clue" : "answer"));
        }

        /// <summary>
        /// toggles sorting based on clue or answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnToggled(object sender, ToggledEventArgs e)
        {
            sortByClue = !sortByClue;
            EntriesLV.ItemsSource = MauiProgram.ibl.GetEntries((sortByClue ? "clue" : "answer"));
        }

        /// <summary>
        /// adds entry 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AddEntry(System.Object sender, System.EventArgs e)
        {
            String clue = clueENT.Text;
            String answer = answerENT.Text.ToUpper();
            String date = dateENT.Text;

            int difficulty;
            bool validDifficulty = int.TryParse(difficultyENT.Text, out difficulty);
            if (validDifficulty)
            {
                InvalidFieldError invalidFieldError = MauiProgram.ibl.AddEntry(clue, answer, difficulty, date);
                if (invalidFieldError != InvalidFieldError.NoError)
                {
                    DisplayAlert("An error has occurred while adding an entry", $"{invalidFieldError}", "OK");
                }
            }
            else
            {
                DisplayAlert("Difficulty", $"Please enter a valid number", "OK");
            }
        }

        /// <summary>
        /// deletes entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DeleteEntry(System.Object sender, System.EventArgs e)
        {
            Entry selectedEntry = EntriesLV.SelectedItem as Entry;
            EntryDeletionError entryDeletionError = MauiProgram.ibl.DeleteEntry(selectedEntry.Id);
            if (entryDeletionError != EntryDeletionError.NoError)
            {
                DisplayAlert("An error has occurred while deleting an entry", $"{entryDeletionError}", "OK");
            }
        }

        /// <summary>
        /// edits entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EditEntry(System.Object sender, System.EventArgs e)
        {

            Entry selectedEntry = EntriesLV.SelectedItem as Entry;
            selectedEntry.Clue = clueENT.Text;
            selectedEntry.Answer = answerENT.Text;
            selectedEntry.Date = dateENT.Text;


            int difficulty;
            bool validDifficulty = int.TryParse(difficultyENT.Text, out difficulty);
            if (validDifficulty)
            {
                selectedEntry.Difficulty = difficulty;
                Console.WriteLine($"Difficuilt is {selectedEntry.Difficulty}");
                EntryEditError entryEditError = MauiProgram.ibl.EditEntry(selectedEntry.Clue, selectedEntry.Answer, selectedEntry.Difficulty, selectedEntry.Date, selectedEntry.Id);
                if (entryEditError != EntryEditError.NoError)
                {
                    DisplayAlert("An error has occurred while editing an entry", $"{entryEditError}", "OK");
                }
            }


        }

        /// <summary>
        /// neat way to grab the selected entry. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void EntriesLV_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
        {
            Entry selectedEntry = e.SelectedItem as Entry;
            clueENT.Text = selectedEntry.Clue;
            answerENT.Text = selectedEntry.Answer;
            difficultyENT.Text = selectedEntry.Difficulty.ToString();
            dateENT.Text = selectedEntry.Date;

        }




    }
}

