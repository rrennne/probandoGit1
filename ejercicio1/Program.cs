// Fig. 11.4: Empleado.cs
// La clase base abstracta Empleado.
public abstract class Empleado
{
private string primerNombre;
private string apellidoPaterno;
private string numeroSeguroSocial;
// constructor con tres parámetros
 public Empleado( string nombre, string apellido, string nss )
 {
 primerNombre = nombre;
 apellidoPaterno = apellido;
 numeroSeguroSocial = nss;
 } // fin de constructor de Empleado con tres parámetros

 // propiedad de sólo lectura que obtiene el primer nombre del empleado
 public string PrimerNombre
 {

get
 {
 return primerNombre;
 } // fin de get
 } // fin de la propiedad PrimerNombre

 // propiedad de sólo lectura que obtiene el apellido paterno del empleado
 public string ApellidoPaterno
 {
 get
 {
 return apellidoPaterno;
 } // fin de get
 } // fin de la propiedad ApellidoPaterno

 // propiedad de sólo lectura que obtiene el número de seguro social del empleado
 public string NumeroSeguroSocial
 {
 get
 {
 return numeroSeguroSocial;
 } // fin de get
 } // fin de la propiedad NumeroSeguroSocial

 // devuelve representación string del objeto Empleado, usando las propiedades
 public override string ToString()
 {
 return string.Format( "{0} {1}\nnúmero de seguro social: {2}",
 PrimerNombre, ApellidoPaterno, NumeroSeguroSocial );
 } // fin del método ToString

 // método abstracto redefinido por las clases derivadas
 public abstract decimal Ingresos(); // no hay implementación aquí
 } // fin de la clase abstracta Empleado







 // Fig. 11.5: EmpleadoAsalariado.cs
 // La clase EmpleadoAsalariado que extiende a Empleado.
 public class EmpleadoAsalariado : Empleado
 {
 private decimal salarioSemanal;

 // constructor con cuatro parámetros
 public EmpleadoAsalariado( string nombre, string apellido, string nss,
 decimal salario ) : base( nombre, apellido, nss )
 {
 SalarioSemanal = salario; // valida el salario a través de una propiedad
 } // fin del constructor de EmpleadoAsalariado con cuatro parámetros

 // propiedad que obtiene y establece el salario del empleado asalariado
 public decimal SalarioSemanal
 {
 get
 {
 return salarioSemanal;
 } // fin de get
 set
 {
 salarioSemanal = ( ( value >= 0 ) ? value : 0 ); // validación
 } // fin de set
 } // fin de la propiedad SalarioSemanal

 // calcula los ingresos; redefine el método abstracto Ingresos en Empleado
 public override decimal Ingresos()
 {
 return SalarioSemanal;
 } // fin del método Ingresos

 // devuelve representación string del objeto EmpleadoAsalariado
 public override string ToString()
 {
 return string.Format( "empleado asalariado: {0}\n{1}: {2:C}",
 base.ToString(), "salario semanal", SalarioSemanal );
 } // fin del método ToString
 } // fin de la clase EmpleadoAsalariado





// Fig. 11.6: EmpleadoPorHoras.cs
 // La clase EmpleadoPorHoras que extiende a Empleado.
 public class EmpleadoPorHoras : Empleado
 {
 private decimal sueldo; // sueldo por hora
 private decimal horas; // horas trabajadas durante la semana

 // constructor con cinco parámetros
 public EmpleadoPorHoras( string nombre, string apellido, string nss,
 decimal sueldoPorHoras, decimal horasTrabajadas )
 : base( nombre, apellido, nss )
 {
 Sueldo = sueldoPorHoras; // valida el sueldo por horas a través de una propiedad
 Horas = horasTrabajadas; // valida las horas trabajadas a través de una propiedad
 } // fin del constructor de EmpleadoPorHoras con cinco parámetros

 // propiedad que obtiene y establece el sueldo del empleado por horas
 public decimal Sueldo
 {
 get
 {
 return sueldo;
 } // fin de get
 set
 {
 sueldo = ( value >= 0 ) ? value : 0; // validación
 } // fin de set
 } // fin de la propiedad Sueldo

 // propiedad que obtiene y establece las horas del empleado por horas
 public decimal Horas
 {
 get
 {
 return horas;
 } // fin de get
 set
 {
 horas = ( ( value >= 0 ) && ( value <= 168 ) ) ?
 value : 0; // validación
 } // fin de set
 } // fin de la propiedad Horas

 // calcula los ingresos; redefine el método abstracto Ingresos de Empleado
 public override decimal Ingresos()
 {
 if ( Horas <= 40 ) // no hay tiempo extra

 return Sueldo * Horas;
 else
 return ( 40 * Sueldo ) + ( ( Horas - 40 ) * Sueldo * 1.5M );
 } // fin del método Ingresos

 // devuelve representación string del objeto EmpleadoPorHoras
 public override string ToString()
 {
 return string.Format(
 "empleado por horas: {0}\n{1}: {2:C}; {3}: {4:F2}",
 base.ToString(), "sueldo por horas", Sueldo, "horas trabajadas", Horas );
 } // fin del método ToString
 } // fin de la clase EmpleadoPorHoras






 // Fig. 11.7: EmpleadoPorComision.cs
 // La clase EmpleadoPorComision que extiende a Empleado.
 public class EmpleadoPorComision : Empleado
 {
 private decimal ventasBrutas; // ventas semanales totales
 private decimal tarifaComision; // porcentaje de comisión

 // constructor con cinco parámetros
 public EmpleadoPorComision( string nombre, string apellido, string nss,
 decimal ventas, decimal tarifa ) : base( nombre, apellido, nss )
 {
 VentasBrutas = ventas; // valida las ventas brutas a través de una propiedad
 TarifaComision = tarifa; // valida la tarifa de comisión a través de una propiedad
 } // fin del constructor de EmpleadoPorComision con cinco parámetros

 // propiedad que obtiene y establece la tarifa de comisión del empleado por comisión
 public decimal TarifaComision
 {
 get
 {
 return tarifaComision;
 } // fin de get
 set
 {
 tarifaComision = ( value > 0 && value < 1 ) ?
 value : 0; // validación
 } // fin de set
 } // fin de la propiedad TarifaComision

 // propiedad que obtiene y establece las ventas brutas del empleado por comisión
 public decimal VentasBrutas
 {
 get
 {
 return ventasBrutas;
 } // fin de get
 set
 {
 ventasBrutas = ( value >= 0 ) ? value : 0; // validación
 } // fin de set
 } // fin de la propiedad VentasBrutas

 // calcula los ingresos; redefine el método abstracto Ingresos en Empleado
 public override decimal Ingresos()
 {
 return TarifaComision * VentasBrutas;
 } // fin del método Ingresos

 // devuelve representación string del objeto EmpleadoPorComision
 public override string ToString()
 {
 return string.Format( "{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}",
 "empleado por comisión", base.ToString(),
 "ventas brutas", VentasBrutas, "tarifa de comisión", TarifaComision );
 } // fin del método ToString
 } // fin de la clase EmpleadoPorComision





 // Fig. 11.8: EmpleadoBaseMasComision.cs
 // La clase EmpleadoBaseMasComision que extiende a EmpleadoPorComision.
 public class EmpleadoBaseMasComision : EmpleadoPorComision
 {
 private decimal salarioBase; // salario base por semana

 // constructor con seis parámetros
 public EmpleadoBaseMasComision( string nombre, string apellido,
 string nss, decimal ventas, decimal tarifa, decimal salario )
 : base( nombre, apellido, nss, ventas, tarifa )
 {
 SalarioBase = salario; // valida el salario base a través de una propiedad
 } // fin del constructor de EmpleadoBaseMasComision con seis parámetros

 // propiedad que obtiene y establece
 // el salario base del empleado por comisión con salario base
 public decimal SalarioBase
 {
 get
 {
 return salarioBase;
 } // fin de get
 set
 {
 salarioBase = ( value >= 0 ) ? value : 0; // validación
 } // fin de set
 } // fin de la propiedad SalarioBase

 // calcula los ingresos; redefine el método Ingresos en EmpleadoPorComision
 public override decimal Ingresos()
 {
 return SalarioBase + base.Ingresos();
 } // fin del método Ingresos

 // devuelve representación string del objeto EmpleadoBaseMasComision
 public override string ToString()
 {
 return string.Format( "{0} {1}; {2}: {3:C}",
 "salario base +", base.ToString(), "salario base", SalarioBase );
 } // fin del método ToString
 } // fin de la clase EmpleadoBaseMasComision