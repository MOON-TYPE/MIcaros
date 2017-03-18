[![GitHub issues](https://img.shields.io/github/issues/MOON-TYPE/MIcaros.svg)](https://github.com/MOON-TYPE/MIcaros/issues)
[![UnityVersion](https://img.shields.io/badge/Unity-5.5.2p4-orange.svg)](https://unity3d.com/es)
[![Trello](https://img.shields.io/badge/Trello-OFF-red.svg)](https://github.com/MOON-TYPE/MIcaros)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/MOON-TYPE/MIcaros/master/LICENSE)

#MIcaros
---

<p align="center"><img src="https://github.com/MOON-TYPE/MIcaros/blob/master/res/MIcaros.png?raw=true"></p>

MIkaros es una herramienta para facilitar la construccion de elementos **ScriptableObjects** en el motor grafico Unity3D.

## Requisitos

> Es necesario tener [Unity3D][1]. **MIcaros** se ha desarrollado en la version 5.5.2p2, se estima que funcionara en versiones de 4.0+ pero no se ha probado aun.

> Tener en tu proyecto alguna clase que sea scriptable, para poder abrir MIcaros.

## Caracteristicas

+ Creacion de un ScriptableObject desde el menu componentes
+ Creacion de un ScriptableObject desde el menu de navegacion
+ Plug&Play (No necesita de configuracion)

---

## Como se usa

> Cuando tienes creado alguna clase scriptableObject solo tienes que darle a Moon Antonio/MIcaros (O en su defecto la path que le hayas puesto) y seguidamente se abrira un menu.

> Elegir la clase que quieres crear en el popup.

> Darle a crear.

> Reescribir el nombre.

## API
* Llamar a la funcion inicial.
```c#
CrearScriptableObject();
```

---

## Limitaciones

```
Actualmente si intentas abrir MIcaros sin tener ninguna clase ScriptableObject en tu proyecto, no se abrira.
```


[1]: https://unity3d.com
