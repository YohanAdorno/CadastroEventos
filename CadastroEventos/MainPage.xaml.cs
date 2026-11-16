
using CadastroEventos.Models;
using CadastroEventos.Views;

namespace CadastroEventos;

public partial class MainPage : ContentPage
{
    Evento evento = new Evento();

    public MainPage()
    {
        InitializeComponent();

        BindingContext = evento;
    }

    private async void CadastrarEvento_Clicked(
        object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.NomeEvento) ||
            string.IsNullOrWhiteSpace(evento.LocalEvento) ||
            evento.NumeroParticipantes <= 0 ||
            evento.CustoPorParticipante < 0)
        {
            await DisplayAlert(
                "Atenção",
                "Preencha todos os campos corretamente.",
                "OK");

            return;
        }

        if (evento.DataTermino < evento.DataInicio)
        {
            await DisplayAlert(
                "Atenção",
                "A data de término não pode ser anterior à data de início.",
                "OK");

            return;
        }

        await Navigation.PushAsync(new ResumoPage(evento));
    }
}
