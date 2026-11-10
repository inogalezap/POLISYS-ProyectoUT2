using System.Diagnostics;
using System.Numerics;
//Variables necesarias para el proyecto
int usuario = 0;
string? AgenteResponsable = "";
string? ciudadano = "";
string? ciudadanoMax = "";
double Intervecion = 0;
double recurso = 0;
double urgencia = 0;
double total = 0;
double numeroIntervencion = 0;
double descuento = 0;
double presupuestoAsignado = 0;
double numeroEstdisticas = 0;
double recaudacionFinal = 0; 
double importeMax = 0;
do
{
    //Menu principal
     
    Console.Clear();
    Console.WriteLine("-------------POLISYS-----------");
    Console.WriteLine("[1] Registrar nueva intervencion");
    Console.WriteLine("[2] Consultar estadisticas");
    Console.WriteLine("[3] Salir del programa");
    Console.Write("Seleccione una opción: ");
    usuario = Convert.ToInt32(Console.ReadLine());
    
    switch (usuario)
    {
        case 1:
        do
        {
        int importeRecursos = 0;
        int SuplementoUrgente = 0;
        int importe = 0;
        bool patrulla = false;
        bool equipoTecnico = false;
        bool registrofotografico = false;
       
        //Pide los nombres del agente y del ciudadano (si el nombre esta vacio este se lo pedira de nuevo)
        Console.WriteLine("NUEVA INTERVENCIÓN");
        Console.WriteLine("------------------");
       do
       {
        Console.Write("Nombre de agente asociado: ");
        AgenteResponsable = Console.ReadLine()?.Trim();
        if (AgenteResponsable == "")
        {
            Console.WriteLine("El nombre no puede estar vacio. Intentalo de nuevo");
        }
       } while (AgenteResponsable == "");
       do
       {
        Console.Write("Nombre de ciudadano asociado: ");
        ciudadano = Console.ReadLine()?.Trim();
        if (ciudadano == "")
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("El nombre no puede estar vacio. Intentalo de nuevo");
            Console.WriteLine("--------------------------------------------------");
        }
       } while (ciudadano == "");
        Console.Clear();

        //se selecciona el tipo de intervencion
        do
        {
        Console.WriteLine("----------TIPO INTERVECIÓN EXTRA-------------- ");
        Console.WriteLine("[1] Interveción básica - 30€");
        Console.WriteLine("[2] Intervención de tráfico - 50€");
        Console.WriteLine("[3] Intervención de investigación - 80€");
        Console.Write("Seleccione un tipo de intervención: ");
        Intervecion = Convert.ToInt32(Console.ReadLine());
        
        if (Intervecion == 1)
            {
                importe += 30;
            } else if (Intervecion == 2)
            {
                importe += 50;
            } else if (Intervecion == 3)
            {
                importe += 80;
            } else
            {
                Console.WriteLine("Elige una opcion dentro de las correctas");
                Console.WriteLine("Pulse cualquier tecla para repetir...");
                Console.ReadKey();
            }
            Console.Clear();
        } while (Intervecion < 1 || Intervecion > 3);

            do {
            //Se selecciona los recursos adicionales
            Console.WriteLine("----------RECURSOS ADICIONALES--------------- ");
            Console.WriteLine("[1] Patrulla adicional - 20");
            Console.WriteLine("[2] Equipo técnico - 35€");
            Console.WriteLine("[3] Registro fotográfico - 15€");
            Console.WriteLine("[0] Finalizar selección");
            Console.Write("Seleccione un tipo de intervención: ");
            recurso = Convert.ToInt32(Console.ReadLine());
            //Dependiendo de si el usuario selecciona un tipo de numero se suma y solo puede seleccionarlo una vez 
            //pasa a ser true y no puede realizar la operacion otra vez (para los tres if)
            //pulsa cero para pasar al siguiente menu
            if (recurso == 1)
            {
                if (patrulla == false)
                {
                    Console.Clear();
                    importeRecursos += 20;
                    patrulla = true;
                    Console.WriteLine("patrulla adicional seleccionada");
                } else
                    {
                        Console.Clear();
                        Console.WriteLine("La patrulla ya esta seleccionada");
                    }
            } else if (recurso == 2)
            {
                if (equipoTecnico == false)
                    {
                        Console.Clear();
                        importeRecursos += 35;
                        equipoTecnico = true;
                        Console.WriteLine("Equipo tecnico seleccionado");
                    } else
                    {
                        Console.Clear();
                        Console.WriteLine("El equipo tecnico ya esta seleccionado");
                    }
            } else if (recurso == 3)
            {
              if (registrofotografico == false)
              {
                Console.Clear();
                importeRecursos += 15;
                registrofotografico = true;
                Console.WriteLine("Registro fotografico seleccionado");
              }   else
                    {
                        Console.Clear();
                        Console.WriteLine("El registro ya esta seleccionado");
                    }
            } else if (recurso != 0)
            {
                Console.Clear();
                Console.WriteLine("Elige una opcion correcta*");
            }
             
        } while (recurso != 0);

            //La urgencia puede elegir si es normal o urgente en este segundo caso se suma 25 euros mas
            Console.Clear();
            Console.WriteLine("----------URGENCIA------------ ");
            Console.WriteLine("[1] Intervención normal");
            Console.WriteLine("[2] Intervención urgente");
            Console.Write("Seleccione la urgencia: ");
            urgencia = Convert.ToInt32(Console.ReadLine());
            if (urgencia == 1)
                {
                    urgencia = urgencia + 0;
                }
            if (urgencia == 2)
            {
                Console.WriteLine("Intervención urgente (+25€)");
                SuplementoUrgente += 25;
            }
            //si la suma de todo lo anterior es mas de 100 se le aplica un descuento del 0,10% 
            total = importe + importeRecursos + SuplementoUrgente;
            if (total >= 100)
                {
                     descuento = total * 0.10;
                } else
                {
                    descuento = 0;
                }
            //Calucla el total final, actualiza el record si es la intervencion mas cara y acumula el importe de recaudacion
            double totalFinal = total - descuento;
            if (totalFinal > importeMax)
                {
                    importeMax = totalFinal;
                    ciudadanoMax = ciudadano;
                } 
            recaudacionFinal += totalFinal;
            Console.Clear();
        do
        {
            //Aqui se enseña un resumen de lo que ha ido marcando con sus sumas
            Console.WriteLine("----------RESUMEN DEL PRESUPUESTO--------");
            Console.WriteLine("Tipo de investigación: "+importe);
            Console.WriteLine("Recursos adicionales: "+importeRecursos);
            Console.WriteLine("Suplemento urgente: "+SuplementoUrgente);
            Console.WriteLine("Descuento (10 %): "+descuento);
            Console.WriteLine("PRESUPUESTO: "+ totalFinal);
            Console.WriteLine();
            Console.WriteLine("---------PAGO EN EFECTIVO------");
            Console.WriteLine("Introduzca el presupuesto asignado: ");
            presupuestoAsignado = Convert.ToDouble(Console.ReadLine());

            if (presupuestoAsignado < totalFinal)
            {
                Console.Clear();
                Console.WriteLine("Dinero insuficiente, falta: "+(total-presupuestoAsignado));
                Console.WriteLine("Por favor, introduzca una cantidad igual o superior al total.");
                Console.WriteLine("Presione cualquier tecla para volver a intentarlo...");
                Console.ReadKey();
                Console.Clear();

            }   
        } while (presupuestoAsignado < totalFinal);

                numeroEstdisticas += 1;
                numeroIntervencion ++;
                Console.WriteLine("================================");
                Console.WriteLine("             POLISYS");  
                Console.WriteLine("=================================");
                Console.WriteLine("Numero de intervención: "+numeroIntervencion);
                Console.WriteLine("");
                Console.WriteLine("Agente responsable: "+AgenteResponsable);
                Console.WriteLine("Ciudadano relacionado: "+ciudadano);
                Console.WriteLine("");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("RESUMEN ECONOMICO");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Coste de intervención: "+importe);
                Console.WriteLine("Recursos adicionales: "+importeRecursos);
                Console.WriteLine("Suplemento urgente: "+SuplementoUrgente);
                Console.WriteLine("Descuento aplicado (10%): "+descuento);
                Console.WriteLine("");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("TOTAL ESTIMADO:             "+totalFinal);
                Console.WriteLine("----------------------------------");
                Console.WriteLine("===================================");
                Console.WriteLine("      INTERVENCION REGISTRADA      ");
                Console.WriteLine("===================================");
                Console.Write("Escribe CERO para salir al menu principal: ");
                recurso = Convert.ToInt32(Console.ReadLine());
                
        } while (recurso != 0);
       break;
        case 2:
        //Un menu de la ultimas estadisticas realizadas 
        if (numeroEstdisticas == 0)
        {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("   POLISYS - ESTADÍSTICAS");
        Console.WriteLine("==================================");
        Console.WriteLine("[!] Aviso no se ha registrado");
        Console.WriteLine("    ninguna intervención todavía.");
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Presione una telcla para volver....");
        Console.ReadKey();
        } else {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("   POLISYS - ESTADÍSTICAS");
        Console.WriteLine("=================================="); 
        Console.WriteLine();
        Console.WriteLine("Operaciones cobradas: "+numeroEstdisticas);
        Console.WriteLine("Recaudacion total: "+recaudacionFinal);
        Console.WriteLine("Importe medio: "+(recaudacionFinal / numeroEstdisticas).ToString("F2") + "€");//.ToString("F2") hace que salga dos digitos decimales primeros y despues de la coma dos mas.
        Console.WriteLine("Intervencion mas cara: "+importeMax.ToString("F2") + "€");
        Console.WriteLine("Ultimo agente asociado: "+AgenteResponsable);
        Console.WriteLine("ciudadano registrado mas caro: "+ciudadanoMax);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Preciona una tecla para volver...");
        Console.ReadKey();
        }
        break;
        default:
        Console.WriteLine("Elija una opcion válida");
        Console.WriteLine("Pulse cualquier tecla para volver...");
        Console.ReadKey();
        break;
    }
} while (usuario != 3);