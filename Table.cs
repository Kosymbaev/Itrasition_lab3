using System;
using System.Collections.Generic;
using System.Data;

namespace Task3
{
    public class Table
    {
        public Table(List<string> turns)
        {
            DataTable orderDetailTable = CreateOrderDetailTable(turns);

            InsertOrderDetails(orderDetailTable, turns);


            Console.WriteLine("The OrderDetail table");
            ShowTable(orderDetailTable, turns);
        }

        private static DataTable CreateOrderDetailTable(List<string> array)
        {
            DataTable orderDetailTable = new DataTable("OrderDetail");

            // Define all the columns once.
            DataColumn[] cols = new DataColumn[array.Count() + 1];
            cols[0] = new DataColumn("names", typeof(string));
            for (int i = 0; i < array.Count(); i++)
            {
                cols[i + 1] = new DataColumn(array[i], typeof(string));
            }
            orderDetailTable.Columns.AddRange(cols);
            return orderDetailTable;
        }
        private static void InsertOrderDetails(DataTable orderDetailTable, List<string> array)
        {
            var win = new Rules();
            for (int i = 0; i < array.Count(); i++)
            {
                var row = new Object[array.Count()+1];
                row[0] = array[i];
                for (int j = 0; j < array.Count(); j++)
                {
                    switch (win.Winer(array, j, i))
                    {
                        case 1:
                            row[j+1] = array[j] +" WIN";
                            break;
                        case -1:
                            row[j+1] = array[j] + " LOSE";
                            break;
                        case 0:
                            row[j+1] = array[j] + " DRAW";
                            break;
                    }
                }
                orderDetailTable.Rows.Add(row);
            }
        }
        private void ShowTable(DataTable table, List<string> choice)
        {
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,-30}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.Write("{0,-30}", row[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
