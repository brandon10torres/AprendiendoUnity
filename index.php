<?php

	$host = 'localhost';
	$user = 'root';
	$pass = '';
	$db = 'cursoudemy';
	$nombreTabla = 'infinityrun';
	$conexion = mysqli_connect($host, $user, $pass, $db) or die('No se puede conectar ' . mysql_error());

	//InsertarElemento($conexion, $nombreTabla);
	//SeleccionarElementos($conexion, $nombreTabla);
	//BorrarElementos($conexion, $nombreTabla);
	//ActualizarElementos($conexion, $nombreTabla);

	$tipoLlamadaBD = $_REQUEST['tipoLlamadaBD'];

	if($tipoLlamadaBD == "checkUsuario")
	{
		$usuarioCheck = $_REQUEST['usuarioCheck'];
		$resultadoLogin = LoginUsuario($conexion, $nombreTabla, $usuarioCheck);
		echo $resultadoLogin;
	}
	else if($tipoLlamadaBD == "insertPuntos")
	{
		$usuarioCheck = $_REQUEST['usuarioCheck'];
		$puntuacionUsuario = $_REQUEST['puntuacionUsuario'];
		UpdatePuntuacion($conexion, $nombreTabla, $usuarioCheck, $puntuacionUsuario); 
	}
	else if($tipoLlamadaBD == "getRanking")
	{
		$infoRank = ObtenerRanking($conexion, $nombreTabla);
		echo $infoRank;
	}



	/*function InsertarElemento($conexion, $nombreTabla)
	{
		$queryInsert = "insert into " . $nombreTabla . " (Usuario, Puntuacion, UltimaVezJugado) values ('prueba', 17, '29-09-2017')";
		$resultadoInsert = mysqli_query($conexion, $queryInsert) or die('La consulta falló ' . mysql_error());
		echo "Ingresado";
	}*/

	/*function SeleccionarElementos($conexion, $nombreTabla)
	{
		$querySelect = "select * from " . $nombreTabla . " where Usuario = 'Brandon'";
		$resultadoSelect = mysqli_query($conexion, $querySelect) or die('La consulta falló ' . mysql_error());
		$fila = mysqli_fetch_array($resultadoSelect);
		echo $fila['Usuario'];
		echo " | ";
		echo $fila['Puntuacion'];
	}*/

	/*function BorrarElementos($conexion, $nombreTabla)
	{
		$queryDelete = "delete from " . $nombreTabla . " where Usuario = 'prueba'";
		$resultadoDelete = mysqli_query($conexion, $queryDelete) or die('La consulta falló ' . mysql_error());
		echo "Borrado";
	}*/

	/*function ActualizarElementos($conexion, $nombreTabla)
	{
		$queryUpdate = "update " . $nombreTabla . " set Puntuacion = 100 where Usuario = 'prueba'";
		$resultadoUpdate = mysqli_query($conexion, $queryUpdate) or die('La consulta falló ' . mysql_error());
		echo "Actualizado";
	}*/

	function LoginUsuario($conexion, $nombreTabla, $usuarioCheck)
	{
		$querySelect = "select * from " . $nombreTabla . " where Usuario = '" . $usuarioCheck . "'";
		$resultadoSelect = mysqli_query($conexion, $querySelect) or die('La consulta falló ' . mysql_error());

		$numResultados = mysqli_num_rows($resultadoSelect);

		if($numResultados > 0)
		{
			return "YaExiste";
		}
		else
		{
			$hoy = getdate();
			$anio = $hoy[year];
			$mes = $hoy[mon];
			$dia = $hoy[mday];

			$ultimaJugada = $dia . "/" . $mes . "/" . $anio;

			$queryInsert = "insert into " . $nombreTabla . " (Usuario, Puntuacion, UltimaVezJugado) values ('" . $usuarioCheck . "', 0, '" . $ultimaJugada . "')";
			$resultadoInsert = mysqli_query($conexion, $queryInsert) or die('La consulta falló ' . mysql_error());

			return "Insertado";
		}
	}

	function UpdatePuntuacion($conexion, $nombreTabla, $usuarioCheck, $puntuacionUsuario)
	{
		$hoy = getdate();
		$anio = $hoy[year];
		$mes = $hoy[mon];
		$dia = $hoy[mday];

		$ultimaJugada = $dia . "/" . $mes . "/" . $anio;

		$queryUpdate = "update " . $nombreTabla . " set Puntuacion = " . $puntuacionUsuario . ", UltimaVezJugado = '" . $ultimaJugada . "' where Usuario ='" . $usuarioCheck . "'";
		//prueba
		$resultadoUpdate = mysqli_query($conexion, $queryUpdate) or die('La consulta falló ' . mysql_error());
		echo "Actualizado";
	}

	function ObtenerRanking($conexion, $nombreTabla)
	{
		$querySelect = "select * from " . $nombreTabla . " where Puntuacion > 0  order by Puntuacion desc limit 10";
		$resultadoSelect = mysqli_query($conexion, $querySelect) or die('La consulta falló ' . mysql_error());
		
		$numResultados = mysqli_num_rows($resultadoSelect);

		$i=0;
		$infoRanking ="";
		while($i < $numResultados)
		{
			$fila = mysqli_fetch_array($resultadoSelect);
			$infoRanking = $infoRanking . $fila['Usuario'] . "#";
			$i++;
		}
		return $infoRanking;
	}

?>