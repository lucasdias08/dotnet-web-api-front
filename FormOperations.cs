using a3_202401.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace a3_202401
{
    public partial class FormOperations : Form
    {
        private const string todoTaskUrl = "http://localhost:5100/";
        private bool isForEdit = false;
        FormInitial formInitial { get; set; }
        TodoTask TodoTask { get; set; }
        public FormOperations()
        {
            InitializeComponent();
        }
        public FormOperations(TodoTask todoTask, FormInitial formInitial)
        {
            this.TodoTask = todoTask;
            this.formInitial = formInitial;
            this.isForEdit = !string.IsNullOrEmpty(TodoTask.Title) && !string.IsNullOrEmpty(TodoTask.Description);
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TodoTask.Title) && !string.IsNullOrEmpty(TodoTask.Description))
            {
                buttonTodoTaskDelete.Enabled = true;
                titleTextBox.Text = TodoTask.Title;
                textDescriptionRichBox.Text = TodoTask.Description;
            }
            else
            {
                buttonTodoTaskDelete.Enabled = false;
            }
        }

        private async void buttonSaveTask_Click(object sender, EventArgs e)
        {
            string textTitle = titleTextBox.Text.Trim();
            string textDescription = textDescriptionRichBox.Text.Trim();

            Cursor = Cursors.WaitCursor;
            titleTextBox.Enabled = false;
            buttonSaveTask.Enabled = false;
            buttonCancelSaveTask.Enabled = false;
            textDescriptionRichBox.Enabled = false;
            buttonTodoTaskDelete.Enabled = false;

            if (!string.IsNullOrEmpty(textTitle) && !string.IsNullOrEmpty(textDescription))
            {
                using (var httpClient = new HttpClient())
                {
                    TodoTask task = new TodoTask();
                    task.Title = textTitle;
                    task.Description = textDescription;

                    HttpResponseMessage httpResponse = null;

                    try
                    {
                        string taskSerialized = System.Text.Json.JsonSerializer.Serialize(task);
                        var content = new StringContent(taskSerialized, Encoding.UTF8, "application/json");
                        
                        if(isForEdit) httpResponse = await httpClient.PutAsync(todoTaskUrl + "api/task/" + TodoTask.Id, content);
                        else httpResponse = await httpClient.PostAsync(todoTaskUrl + "api/task", content);

                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            formInitial.onLoadFormInitial(false);
                            string responseBody = await httpResponse.Content.ReadAsStringAsync();
                            ResponseApi responseFormatted = JsonConvert.DeserializeObject<ResponseApi>(responseBody)!;

                            MessageBox.Show(responseFormatted?.Message, "Sucesso", MessageBoxButtons.OK);
                            this.Dispose();
                            Cursor = Cursors.Default;
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Erro na requisição HTTP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelSaveTask_Click(object sender, EventArgs e) => this.Dispose();

        private async void buttonTodoTaskDelete_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            titleTextBox.Enabled = false;
            buttonSaveTask.Enabled = false;
            buttonCancelSaveTask.Enabled = false;
            textDescriptionRichBox.Enabled = false;
            buttonTodoTaskDelete.Enabled = false;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponse = await httpClient.DeleteAsync(todoTaskUrl + "api/task/" + TodoTask.Id);
                    
                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string responseBody = await httpResponse.Content.ReadAsStringAsync();
                        formInitial.onLoadFormInitial(false);
                        ResponseApi responseFormatted = JsonConvert.DeserializeObject<ResponseApi>(responseBody);
                        MessageBox.Show(responseFormatted?.Message, "Sucesso", MessageBoxButtons.OK);
                        this.Dispose();
                        Cursor = Cursors.Default;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição HTTP: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
