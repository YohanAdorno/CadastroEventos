
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CadastroEventos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nomeEvento;
        private DateTime dataInicio = DateTime.Today;
        private DateTime dataTermino = DateTime.Today;
        private int numeroParticipantes;
        private string localEvento;
        private decimal custoPorParticipante;

        public string NomeEvento
        {
            get => nomeEvento;
            set
            {
                nomeEvento = value;
                OnPropertyChanged();
            }
        }

        public DateTime DataInicio
        {
            get => dataInicio;
            set
            {
                dataInicio = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duracao));
                OnPropertyChanged(nameof(DuracaoDias));
            }
        }

        public DateTime DataTermino
        {
            get => dataTermino;
            set
            {
                dataTermino = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Duracao));
                OnPropertyChanged(nameof(DuracaoDias));
            }
        }

        public int NumeroParticipantes
        {
            get => numeroParticipantes;
            set
            {
                numeroParticipantes = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public string LocalEvento
        {
            get => localEvento;
            set
            {
                localEvento = value;
                OnPropertyChanged();
            }
        }

        public decimal CustoPorParticipante
        {
            get => custoPorParticipante;
            set
            {
                custoPorParticipante = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CustoTotal));
            }
        }

        public TimeSpan Duracao
        {
            get => DataTermino - DataInicio;
        }

        public int DuracaoDias
        {
            get => Duracao.Days;
        }

        public decimal CustoTotal
        {
            get => NumeroParticipantes * CustoPorParticipante;
        }

        protected void OnPropertyChanged(
            [CallerMemberName] string nome = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nome));
        }
    }
}
