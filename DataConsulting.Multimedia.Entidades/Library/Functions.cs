using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
using System.Reflection;
using System.Data.OleDb;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DataConsulting.Multimedia.Entidades
{   
    public static class FunctionsBR
    {
        public static Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
        public static void CopyObject(object source, object target)
        {
            foreach (System.Reflection.PropertyInfo property in source.GetType().GetProperties())
                if(property.CanWrite)
                    property.SetValue(target, property.GetValue(source, null), null);
        }

        public static int MonthDiff(DateTime date1, DateTime date2)
        {
            return date2.Month - date1.Month + 12 * (date2.Year - date1.Year); 
        }

        public static string FormatDate(DateTime date, int format)
        {
            if (format == 1) // Formato Juliano dddyy
                return date.DayOfYear.ToString("D3") + date.ToString("yy");
            else // Formato ISO yyyymmdd
                return date.ToString("yyyyMMdd");
        }

        public static DateTime ParseDate(string dateString, int format)
        {
            if (format == 1) // Formato Juliano dddyy
                return new DateTime(int.Parse(dateString.Right(2)) + 2000, 1, 1).AddDays(int.Parse(dateString.Left(dateString.Length - 2)));
            else // Formato ISO yyyymmdd
                return new DateTime(int.Parse(dateString.Left(4)),
                    int.Parse(dateString.Substring(4, 2)), int.Parse(dateString.Substring(6, 2)));
        }

        public static string Right(this string str, int lenght)
        {
            if (lenght < 0) throw new ArgumentOutOfRangeException();
            int minlength = str.Length > lenght ? lenght : str.Length;
            if (minlength > 0)
                return str.Substring(str.Length - minlength, minlength);
            else
                return string.Empty;
        }

        public static string Left(this string str, int lenght)
        {
            if (lenght < 0) throw new ArgumentOutOfRangeException();
            int minlength = str.Length > lenght ? lenght : str.Length;
            if (minlength > 0)
                return str.Substring(0, minlength);
            else
                return string.Empty;
        }
              
        public static T GetFirst<T>(IList<T> list)
        {
            if (list.Count > 0)
                return list[0];
            else
                return default(T);
        }
                
        public static DateTime FechaSinSegundos(DateTime Value)
        {
            DateTime SinSegundo = new DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, Value.Minute, 0);
            return SinSegundo;
        }

        public static bool IsNumeric(object cadena)
        {
            bool isNumber;
            double isItNumeric;
            isNumber = Double.TryParse(Convert.ToString(cadena), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out isItNumeric);
            return isNumber;
        }

        public static bool IsPar(int numero)
        {
            return (numero % 2) == 0;
        }

        public static bool IsImpar(int numero)
        {
            return (numero % 2) != 0;
        }

         public static string GetStateString(byte Estado)
         {
             switch (Estado)
             {
                 case (byte)EEstado.Activo: return EEstadoGenericoStr.Activo;
                 case (byte)EEstado.Inactivo: return EEstadoGenericoStr.Inactivo;
                 case (byte)EEstado.Todos: return EEstadoGenericoStr.Todos;
                 default: return string.Empty;
             }
         }
        
        public static bool ValidarDNIPeru(string identificationDocument)
        {
            if (!string.IsNullOrEmpty(identificationDocument))
            {
                int addition = 0;
                int[] hash = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int identificationDocumentLength = identificationDocument.Length;

                string identificationComponent = identificationDocument.Substring(0, identificationDocumentLength - 1);

                int identificationComponentLength = identificationComponent.Length;

                int diff = hash.Length - identificationComponentLength;

                for (int i = identificationComponentLength - 1; i >= 0; i--)
                {
                    addition += (identificationComponent[i] - '0') * hash[i + diff];
                }

                addition = 11 - (addition % 11);

                if (addition == 11)
                {
                    addition = 0;
                }

                char last = char.ToUpperInvariant(identificationDocument[identificationDocumentLength - 1]);

                if (identificationDocumentLength == 11)
                {
                    // The identification document corresponds to a RUC.
                    return addition.Equals(last - '0');
                }
                else if (char.IsDigit(last))
                {
                    // The identification document corresponds to a DNI with a number as verification digit.
                    char[] hashNumbers = { '6', '7', '8', '9', '0', '1', '1', '2', '3', '4', '5' };
                    return last.Equals(hashNumbers[addition]);
                }
                else if (char.IsLetter(last))
                {
                    // The identification document corresponds to a DNI with a letter as verification digit.
                    char[] hashLetters = { 'K', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
                    return last.Equals(hashLetters[addition]);
                }
            }

            return false;
        }

        public static DataTable ReaderToTable(IDataReader Reader)
        {
            DataTable Table = new DataTable();
            Table.Load(Reader);
            Reader.Close();
            return Table;
        }

        //Funciones de Fecha adicionales
        public static System.DateTime FirstDayOfWeek(System.DateTime Value)
        {
            return Value.AddDays(1 - (Value.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)Value.DayOfWeek)).Date;
        }

        public static System.DateTime LastDayOfWeek(System.DateTime Value)
        {
            return Value.AddDays(7 - (Value.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)Value.DayOfWeek)).Date;
        }

        public static System.DateTime FirstDayOfMonth(System.DateTime Value)
        {
            return Value.AddDays(1 - Value.Day).Date;
        }

        public static System.DateTime LastDayOfMonth(System.DateTime Value)
        {
            return Value.AddDays(System.DateTime.DaysInMonth(Value.Year, Value.Month) - Value.Day).Date;
        }

        //Funciones de Fecha de Anio
        public static System.DateTime FirstDayOfYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        public static System.DateTime LastDayOfYear(int year)
        {
            return (new DateTime(year + 1, 1, 1)).AddDays(-1);
        }

        public static string Decrypt(string decodeMe)
        {
            try
            {
                byte[] encoded = Convert.FromBase64String(decodeMe);
                return System.Text.Encoding.UTF8.GetString(encoded);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string Encrypt(string encodeMe)
        {
            try
            {
                byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
                return Convert.ToBase64String(encoded);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string AsignarTipoNombre(byte Tipo)
        {
            string NombreTipo = string.Empty;
            switch (Tipo)
            {
                case (byte)ETipoEstadoSunat.NoEnviado:
                    NombreTipo = ETipoNombre.NoEnviado; break;
                case (byte)ETipoEstadoSunat.Aceptado:
                    NombreTipo = ETipoNombre.Aceptado; break;
                case (byte)ETipoEstadoSunat.Rechazado:
                    NombreTipo = ETipoNombre.Rechazado; break;
                case (byte)ETipoEstadoSunat.Emitido:
                    NombreTipo = ETipoNombre.Emitido; break;
                case (byte)ETipoEstadoSunat.Restante:
                    NombreTipo = ETipoNombre.Restante; break;
            }

            return NombreTipo;
        }

        public static string NumberFormat(int fixedDecimals, int extraDecimals = 0)
        {
            string format = "#,##0";
            if (fixedDecimals > 0 || extraDecimals > 0)
                format += ".";
            if (fixedDecimals > 0)
                format += new string('0', fixedDecimals);
            if (extraDecimals > 0)
                format += new string('#', extraDecimals);
            return format;
        }

        public static string ExtraerNumeros(string Cadena)
        {
            string numeros = string.Empty;
            int caracter = 0;

            for (int i = 0; i < Cadena.Count(); i++)
            {
                try
                {
                   caracter = DbConvert.ToInt32(Cadena.Substring(i,1));
                   numeros = numeros + caracter;
                }
                catch (Exception)
                {
                }

            }
            return numeros;
        }

        public static void PropertySet(object p, string propName, object value)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
                return;
            if (!info.CanWrite)
                return;

            info.SetValue(p, Convert.ChangeType(value, info.GetType()), null);
        }

        public static string ToFormFechaMMDDYY(string fecha)
        {
            try
            {
                if (fecha.Length == 9)
                    fecha = "0" + fecha;
                string mes = fecha.Substring(0, 2);
                string dia = fecha.Substring(3, 2);
                string año = fecha.Substring(6, 4);
                fecha = dia + "-" + mes + "-" + año;
                return fecha;
            }
            catch (Exception)
            {
                throw new Exception("Ingrese un formato de fecha correcto");
            }
           
        }


        public static void WriteBinaryFile(Byte[] aByte, string fileName, bool flagOpen = true)
        {
            if (aByte == null || fileName == "")
            {
                throw new Exception("No existe Ruta de destino o la cadena de Bytes");
            }
            try
            {
                //if (File.Exists(fileName))
                //{

                //}
                long data = aByte.Length;
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(aByte, 0, Convert.ToInt32(data));

                bw.Flush();
                bw.Close();
                //bw = null;
                //fs = null;
                //if (flagOpen == true)
                //{
                //    OpenFile(fileName);
                //}
            }
            catch (Exception ex)
            {
                new Exception("Se presento el siguiente problema: "+ex.Message);
                throw;
            }
        }
        public static bool ValidarDNI(string NroDNI)
        {
            bool valor = false;
            if (NroDNI.Length == 8)
            {
                for (int i = 1; i < 8; i++)
                {
                    try
                    {
                        Convert.ToInt32(NroDNI.Substring(i, 1));
                        valor = true;
                    }
                    catch (Exception)
                    {
                        valor = false;
                    }
                }
            }
            return valor;
        }
        public static bool ValidarRUC(string NroRUC)
        {
            NroRUC.Trim();
            int[] MaskRUC = new int[10];
            bool valor = false;

            if (NroRUC.Length == 11)
            {
                MaskRUC[0] = 5;
                MaskRUC[1] = 4;
                MaskRUC[2] = 3;
                MaskRUC[3] = 2;
                MaskRUC[4] = 7;
                MaskRUC[5] = 6;
                MaskRUC[6] = 5;
                MaskRUC[7] = 4;
                MaskRUC[8] = 3;
                MaskRUC[9] = 2;
                int CheckSum = 0;

                for (int i = 0; i < 10; i++)
                {
                    int index = Convert.ToInt32(NroRUC.Substring(i, 1));
                    CheckSum = CheckSum + ((index) * MaskRUC[i]);
                }
                int residuo = CheckSum % 11;
                int UltDigito = (11 - residuo) % 10;
                if (UltDigito == Convert.ToInt32(NroRUC.Substring(10, 1)))
                {
                    valor = true;
                }
            }
            return valor;
        }

        public static DateTime CambiarDiaxMes(DateTime fecha)
        {
            int mes = fecha.Month;
            int dia = fecha.Day;
            int año = fecha.Year;

            try
            {
                DateTime fecharef = DbConvert.ToDateTime("31/08/2016");
                fecha = DbConvert.ToDateTime(mes + "/" + dia + "/" + año);
            }
            catch (Exception)
            {
                try
                {
                    fecha = DbConvert.ToDateTime(dia + "/" + mes + "/" + año);
                }
                catch (Exception)
                {
                    fecha = DbConvert.ToDateTime(mes + "/" + mes + "/" + año);
                }
            }
           
           
            
            return fecha;
        }

        public static System.Data.DataTable ImportFromExcel(string FileName, string SheetName, string Header = null)
        {
            string ConnectionString = string.Empty;
            string FlagFile = string.Empty;
            try
            {
                if (FileName.EndsWith(".xlsx", StringComparison.InvariantCultureIgnoreCase))
                {
                    ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0 Xml;HDR=Yes;IMEX=1\"";
                    FlagFile = "xls";
                }
                else if (FileName.EndsWith(".xls", StringComparison.InvariantCultureIgnoreCase))
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                    FlagFile = "xls";
                }
                else if (FileName.EndsWith(".txt", StringComparison.InvariantCulture))
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(FileName) + ";Extended Properties='text;HDR=" + Header + ";FMT=Delimited'";
                    FlagFile = "txt";
                }
                else if (FileName.EndsWith(".csv", StringComparison.InvariantCultureIgnoreCase))
                {
                    ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.IO.Path.GetDirectoryName(FileName) + ";Extended Properties='text;HDR=" + Header + ";FMT=Delimited'";
                    FlagFile = "csv";
                }
                else { throw new Exception("Utilice archivos de Hoja de Calculo de Excel (*.xls; *.xlsx)"); }

                OleDbConnection Connection = new OleDbConnection(ConnectionString);
                OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
                string qry = string.Empty;
                if (FlagFile == "xls")
                    DataAdapter = new OleDbDataAdapter("SELECT * FROM [" + SheetName + "$]", Connection);
                else if (FlagFile == "csv")
                    DataAdapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(FileName), Connection);
                else
                    DataAdapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(FileName), Connection);
                System.Data.DataTable dtResult = new System.Data.DataTable();
                DataAdapter.Fill(dtResult);
                return dtResult;
            }
            catch (Exception ex)
            {
                string mensa = ex.Message;
                throw;
            }
        }
        public static string GetDateTimeLog()
        {
            return DateTime.Now.ToString("_yyyy_MM_dd_hh_mm_ss");
        }
        public static string CopiarTemporal(string RutaTemplate, string RutaDestino)
        {
            RutaDestino = RutaDestino + GetDateTimeLog() + ".xlsx";
            if (System.IO.File.Exists(RutaDestino))
                System.IO.File.Delete(RutaDestino);
            System.IO.File.Copy(RutaTemplate, RutaDestino);

            return RutaDestino;
        }
        public static void EliminarArchivo(string ruta)
        {
            if (System.IO.File.Exists(ruta))
                System.IO.File.Delete(ruta);
        }



        #region OpenXML
        public static WorksheetPart GetWorksheetPart(WorkbookPart workbookPart, string sheetName)
        {
            string relId = workbookPart.Workbook.Descendants<Sheet>().First(s => sheetName.Equals(s.Name)).Id;
            return (WorksheetPart)workbookPart.GetPartById(relId);
        }

        public static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }
        #endregion

        public static string CompressDirectory(DirectoryInfo directorySelected, string Carpeta)
        {
            try
            {
                Carpeta = Carpeta +".zip";
                using (var zip = ZipFile.Open(Carpeta, ZipArchiveMode.Create))
                {
                    //zip.CreateEntryFromFile(@"c:\something.txt","data/path/something.txt");
                    foreach (FileInfo myFile in directorySelected.GetFiles())
                    {
                        zip.CreateEntryFromFile(myFile.FullName, Path.GetFileName(myFile.FullName), CompressionLevel.Optimal);
                    }
                }
                return Carpeta;
            }
            catch (Exception ex)
            {
                throw new SCOPException("No se pudo comprimir el archivo:" + ex.Message);
            }
        }

        public static void Compress(DirectoryInfo directorySelected, string directoryPath)
        {
            try
            {
                foreach (FileInfo myFile in directorySelected.GetFiles())
                {
                    string FileNameOnly = Path.GetFileNameWithoutExtension(myFile.Name);

                    if ((File.GetAttributes(myFile.FullName) &
                        FileAttributes.Hidden) != FileAttributes.Hidden & myFile.Extension != ".zip")
                    {
                        string NombreZip = directoryPath + "\\" + FileNameOnly + ".zip";
                        if (File.Exists(NombreZip))
                            File.Delete(NombreZip);

                        using (var zip = ZipFile.Open(NombreZip, ZipArchiveMode.Create))
                        {
                            //zip.CreateEntryFromFile(@"c:\something.txt","data/path/something.txt");
                            zip.CreateEntryFromFile(myFile.FullName, Path.GetFileName(myFile.FullName), CompressionLevel.Optimal);
                        }
                    }
                }


            }
            catch(Exception ex)
            {
                throw new SCOPException("No se pudo comprimir el archivo:" + ex.Message);
            }

        }

        public static void DesCompress(string directoryPath, string filename)
        {
            using (ZipArchive archive = ZipFile.OpenRead(directoryPath + filename))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    try
                    {
                        entry.ExtractToFile(Path.Combine(directoryPath, entry.FullName));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
      


    }
}
