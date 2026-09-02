Imports System
Module filtro_de_registros
    Sub Main(args As String())
        Dim ids(19) As Integer
        Dim nombres(19) As String
        Dim categorias(19) As String
        Dim descripciones(19) As String
        Dim valores(19) As Double
        Dim estados(19) As String
        Dim cantidad As Integer = 0
        Dim opcion As Integer
        '----------------------------------------'
        '--|menu_principal_filtro_de_registros|--'
        '----------------------------------------'
        Do
            Console.WriteLine("menu principal filtro de registros")
            Console.WriteLine("1) Registrar registro")
            Console.WriteLine("2) Editar registro")
            Console.WriteLine("3) Listar registros")
            Console.WriteLine("4) Buscar registro")
            Console.WriteLine("5) Eliminar registro")
            Console.WriteLine("6) Filtrar registros")
            Console.WriteLine("7) Mostrar resumen")
            Console.WriteLine("8) Salir")
            Console.Write("Seleccione una opcion: ")
            opcion = Convert.ToInt32(Console.ReadLine())
            Select Case opcion
                '------------------------'
                '--|registrar_registro|--'
                '------------------------'
                Case 1
                    If cantidad >= ids.Length Then
                        Console.WriteLine("No hay espacio para registrar mas registros.")
                    Else
                        Console.Write("Ingrese el nombre del registro: ")
                        Dim nuevoNombre As String = Console.ReadLine()
                        If nuevoNombre = "" Then
                            Console.WriteLine("El nombre no puede estar vacio.")
                        Else
                            Dim registroExiste As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower() = nuevoNombre.ToLower() Then
                                    registroExiste = True
                                End If
                            Next
                            If registroExiste Then
                                Console.WriteLine("No se puede registrar. El registro ya existe.")
                            Else
                                Console.Write("Ingrese la categoria: ")
                                Dim nuevaCategoria As String = Console.ReadLine()
                                Console.Write("Ingrese la descripcion: ")
                                Dim nuevaDescripcion As String = Console.ReadLine()
                                Console.Write("Ingrese el valor: ")
                                Dim nuevoValor As Double = Convert.ToDouble(Console.ReadLine())
                                If nuevoValor < 0 Then
                                    Console.WriteLine("El valor no puede ser negativo.")
                                Else
                                    ids(cantidad) = cantidad + 1
                                    nombres(cantidad) = nuevoNombre
                                    categorias(cantidad) = nuevaCategoria
                                    descripciones(cantidad) = nuevaDescripcion
                                    valores(cantidad) = nuevoValor
                                    estados(cantidad) = "Activo"
                                    cantidad += 1
                                    Console.WriteLine("Registro registrado correctamente.")
                                    Console.WriteLine("ID: " & ids(cantidad - 1) & " | Nombre: " & nombres(cantidad - 1) & " | Categoria: " & categorias(cantidad - 1) & " | Descripcion: " & descripciones(cantidad - 1) & " | Valor: $" & valores(cantidad - 1).ToString("N2") & " | Estado: " & estados(cantidad - 1))
                                End If
                            End If
                        End If
                    End If
                '---------------------'
                '--|editar_registro|--'
                '---------------------'
                Case 2
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del registro a editar: ")
                        Dim idEditar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEditar >= 1 AndAlso idEditar <= cantidad Then
                            Dim posicion As Integer = idEditar - 1
                            Console.Write("Nuevo nombre: ")
                            Dim nuevoNombre As String = Console.ReadLine()
                            If nuevoNombre = "" Then
                                Console.WriteLine("El nombre no puede estar vacio.")
                            Else
                                Dim nombreExiste As Boolean = False
                                For i As Integer = 0 To cantidad - 1
                                    If i <> posicion AndAlso nombres(i).ToLower() = nuevoNombre.ToLower() Then
                                        nombreExiste = True
                                    End If
                                Next
                                If nombreExiste Then
                                    Console.WriteLine("No se puede actualizar. El nombre ya existe.")
                                Else
                                    nombres(posicion) = nuevoNombre
                                    Console.Write("Nueva categoria: ")
                                    categorias(posicion) = Console.ReadLine()
                                    Console.Write("Nueva descripcion: ")
                                    descripciones(posicion) = Console.ReadLine()
                                    Console.Write("Nuevo valor: ")
                                    Dim nuevoValor As Double = Convert.ToDouble(Console.ReadLine())
                                    If nuevoValor < 0 Then
                                        Console.WriteLine("El valor no puede ser negativo.")
                                    Else
                                        valores(posicion) = nuevoValor
                                        Console.WriteLine("Registro actualizado correctamente.")
                                        Console.WriteLine("ID: " & ids(posicion) & " | Nombre: " & nombres(posicion) & " | Categoria: " & categorias(posicion) & " | Descripcion: " & descripciones(posicion) & " | Valor: $" & valores(posicion).ToString("N2") & " | Estado: " & estados(posicion))
                                    End If
                                End If
                            End If
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '----------------------'
                '--|listar_registros|--'
                '----------------------'
                Case 3
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                    End If
                '---------------------'
                '--|buscar_registro|--'
                '---------------------'
                Case 4
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        Console.WriteLine("1) Buscar por ID")
                        Console.WriteLine("2) Buscar por nombre")
                        Console.WriteLine("3) Buscar por categoria")
                        Console.Write("Seleccione una opcion: ")
                        Dim tipoBusqueda As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoBusqueda = 1 Then
                            Console.Write("Ingrese el ID: ")
                            Dim idBuscar As Integer = Convert.ToInt32(Console.ReadLine())
                            If idBuscar >= 1 AndAlso idBuscar <= cantidad Then
                                Dim posicion As Integer = idBuscar - 1
                                Console.WriteLine("ID: " & ids(posicion) & " | Nombre: " & nombres(posicion) & " | Categoria: " & categorias(posicion) & " | Descripcion: " & descripciones(posicion) & " | Valor: $" & valores(posicion).ToString("N2") & " | Estado: " & estados(posicion))
                            Else
                                Console.WriteLine("ID no encontrada.")
                            End If
                        ElseIf tipoBusqueda = 2 Then
                            Console.Write("Ingrese el nombre: ")
                            Dim nombreBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If nombres(i).ToLower().Contains(nombreBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron registros.")
                            End If
                        ElseIf tipoBusqueda = 3 Then
                            Console.Write("Ingrese la categoria: ")
                            Dim categoriaBuscar As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If categorias(i).ToLower().Contains(categoriaBuscar.ToLower()) Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No se encontraron registros en esa categoria.")
                            End If
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '-----------------------'
                '--|eliminar_registro|--'
                '-----------------------'
                Case 5
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        For i As Integer = 0 To cantidad - 1
                            Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                        Next
                        Console.Write("Ingrese el ID del registro a eliminar: ")
                        Dim idEliminar As Integer = Convert.ToInt32(Console.ReadLine())
                        If idEliminar >= 1 AndAlso idEliminar <= cantidad Then
                            Dim posicion As Integer = idEliminar - 1
                            For i As Integer = posicion To cantidad - 2
                                ids(i) = ids(i + 1)
                                nombres(i) = nombres(i + 1)
                                categorias(i) = categorias(i + 1)
                                descripciones(i) = descripciones(i + 1)
                                valores(i) = valores(i + 1)
                                estados(i) = estados(i + 1)
                            Next
                            cantidad -= 1
                            ids(cantidad) = 0
                            nombres(cantidad) = ""
                            categorias(cantidad) = ""
                            descripciones(cantidad) = ""
                            valores(cantidad) = 0
                            estados(cantidad) = ""
                            For i As Integer = 0 To cantidad - 1
                                ids(i) = i + 1
                            Next
                            Console.WriteLine("Registro eliminado correctamente.")
                        Else
                            Console.WriteLine("ID no encontrada.")
                        End If
                    End If
                '-----------------------'
                '--|filtrar_registros|--'
                '-----------------------'
                Case 6
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        Console.WriteLine("1) Filtrar por categoria")
                        Console.WriteLine("2) Filtrar por estado")
                        Console.WriteLine("3) Filtrar por valor minimo")
                        Console.WriteLine("4) Filtrar por valor maximo")
                        Console.WriteLine("5) Mostrar todos")
                        Console.Write("Seleccione un filtro: ")
                        Dim tipoFiltro As Integer = Convert.ToInt32(Console.ReadLine())
                        If tipoFiltro = 1 Then
                            Console.Write("Ingrese la categoria: ")
                            Dim categoriaFiltro As String = Console.ReadLine()
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If categorias(i).ToLower() = categoriaFiltro.ToLower() Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No existen registros en esa categoria.")
                            End If
                        ElseIf tipoFiltro = 2 Then
                            Console.WriteLine("1) Activo")
                            Console.WriteLine("2) Inactivo")
                            Console.Write("Seleccione el estado: ")
                            Dim opcionEstado As Integer = Convert.ToInt32(Console.ReadLine())
                            Dim estadoFiltro As String = ""
                            Select Case opcionEstado
                                Case 1
                                    estadoFiltro = "Activo"
                                Case 2
                                    estadoFiltro = "Inactivo"
                                Case Else
                                    Console.WriteLine("Estado no valido.")
                                    Continue Do
                            End Select
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If estados(i).ToLower() = estadoFiltro.ToLower() Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No existen registros con ese estado.")
                            End If
                        ElseIf tipoFiltro = 3 Then
                            Console.Write("Ingrese el valor minimo: ")
                            Dim valorMinimo As Double = Convert.ToDouble(Console.ReadLine())
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If valores(i) >= valorMinimo Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No existen registros con un valor igual o superior al indicado.")
                            End If
                        ElseIf tipoFiltro = 4 Then
                            Console.Write("Ingrese el valor maximo: ")
                            Dim valorMaximo As Double = Convert.ToDouble(Console.ReadLine())
                            Dim encontrado As Boolean = False
                            For i As Integer = 0 To cantidad - 1
                                If valores(i) <= valorMaximo Then
                                    Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                                    encontrado = True
                                End If
                            Next
                            If Not encontrado Then
                                Console.WriteLine("No existen registros con un valor igual o inferior al indicado.")
                            End If
                        ElseIf tipoFiltro = 5 Then
                            For i As Integer = 0 To cantidad - 1
                                Console.WriteLine("ID: " & ids(i) & " | Nombre: " & nombres(i) & " | Categoria: " & categorias(i) & " | Descripcion: " & descripciones(i) & " | Valor: $" & valores(i).ToString("N2") & " | Estado: " & estados(i))
                            Next
                        Else
                            Console.WriteLine("Opcion no valida.")
                        End If
                    End If
                '---------------------'
                '--|mostrar_resumen|--'
                '---------------------'
                Case 7
                    If cantidad = 0 Then
                        Console.WriteLine("No existen registros registrados.")
                    Else
                        Dim activos As Integer = 0
                        Dim inactivos As Integer = 0
                        Dim valorTotal As Double = 0
                        Dim valorPromedio As Double = 0
                        For i As Integer = 0 To cantidad - 1
                            valorTotal += valores(i)
                            If estados(i) = "Activo" Then
                                activos += 1
                            ElseIf estados(i) = "Inactivo" Then
                                inactivos += 1
                            End If
                        Next
                        valorPromedio = valorTotal / cantidad
                        Console.WriteLine("Total de registros: " & cantidad)
                        Console.WriteLine("Registros activos: " & activos)
                        Console.WriteLine("Registros inactivos: " & inactivos)
                        Console.WriteLine("Valor total: $" & valorTotal.ToString("N2"))
                        Console.WriteLine("Valor promedio: $" & valorPromedio.ToString("N2"))
                    End If
                '------------------------------'
                '--|salir_del_menu_principal|--'
                '------------------------------'
                Case 8
                    Console.WriteLine("Gracias por utilizar Filtro de Registros.")
                Case Else
                    Console.WriteLine("Opcion no valida.")
            End Select
        Loop While opcion <> 8
    End Sub
End Module