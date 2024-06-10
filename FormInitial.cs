using a3_202401.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;

namespace a3_202401
{
    public partial class FormInitial : Form
    {
        private const string todoTaskUrl = "http://localhost:5100/";
        List<dynamic> allTasksCounter = new List<dynamic>();
        public FormInitial()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateTask_Click(object sender, EventArgs e)
        {
            FormOperations form = new FormOperations(new TodoTask("", "", ""), this);
            form.ShowDialog(this);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TodoTask task = new TodoTask(allTasksCounter[listBox.SelectedIndex]["_id"].ToString(), allTasksCounter[listBox.SelectedIndex]["Title"].ToString(), allTasksCounter[listBox.SelectedIndex]["Description"].ToString());
            FormOperations form = new FormOperations(task, this);
            form.ShowDialog(this);
        }

        private void FormInitial_Load(object sender, EventArgs e) => onLoadFormInitial(true);
        
        public async void onLoadFormInitial(bool showTestingServerMessage)
        {
            Cursor = Cursors.WaitCursor;
            buttonCreateTask.Enabled = false;
            listBox.Enabled = false;
            listBox.Items.Clear();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponse = await httpClient.GetAsync(todoTaskUrl + "testingServer");
                    httpResponse.EnsureSuccessStatusCode();

                    if (httpResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string responseBody = await httpResponse.Content.ReadAsStringAsync();
                        ResponseApi responseFormatted = JsonConvert.DeserializeObject<ResponseApi>(responseBody)!;

                        if (showTestingServerMessage) MessageBox.Show(responseFormatted.Message, "Sucesso", MessageBoxButtons.OK);

                        HttpResponseMessage httpResponseTasks = await httpClient.GetAsync(todoTaskUrl + "api/task");
                        httpResponseTasks.EnsureSuccessStatusCode();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                        {
                            string responseBodyTasks = await httpResponseTasks.Content.ReadAsStringAsync();
                            JsonNode responseBodyTasksFormatted = JsonNode.Parse(responseBodyTasks)!;

                            listBox.Items.Clear();
                            allTasksCounter.Clear();
                            foreach (var item in (dynamic)responseBodyTasksFormatted?["TodoTaskList"]!)
                            {
                                listBox.Items.Add(item["Title"].ToString());
                                allTasksCounter.Add(item);
                            }
                        }
                        Cursor = Cursors.Default;
                        buttonCreateTask.Enabled = true;
                        listBox.Enabled = true;
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Erro na requisição HTTP: {todoTaskUrl + "api/task"}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
