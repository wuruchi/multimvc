using System;

namespace DataConsulting.Multimedia.Entidades
{
    public interface IListItemBE
    {
        string Description { get; }
        object Value { get; }
    }

    public class ListItemBE : IListItemBE
    {
        private string msDescription;
        private string msId;
        private object moValue;
        private DateTime miFechaIni;
        private DateTime miFechaFin;

        public ListItemBE(string Description, string Id)
        {
            msDescription = Description;
            msId = Id;
            moValue = Id;
        }

        public ListItemBE(string description, object value)
        {
            msDescription = description;
            moValue = value;
            msId = value.ToString();
        }

        public ListItemBE(string description, object value, DateTime FechaInicio, DateTime FechaFin)
        {
            msDescription = description;
            moValue = value;
            msId = value.ToString();
            miFechaFin = FechaFin;
            miFechaIni = FechaInicio;
        }

        public string Description
        {
            get { return msDescription; }
        }

        public object Value
        {
            get { return moValue; }
            set { moValue = value; }
        }

        public string Id
        {
            get { return msId; }
        }

        public DateTime FechaInicio
        {
            get { return miFechaIni; }
            set { miFechaIni = value; }
        }

        public DateTime FechaFin
        {
            get { return miFechaFin; }
            set { miFechaFin = value; }
        }

    }
}
