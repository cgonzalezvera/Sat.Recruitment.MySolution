# SAT Recruitment

### Autor de la solución: Claudio González Vera

## Lenguaje de programación y frameworks usados
- La plataforma en que se desarrollo es netcore 3.1
- MOQ para hacer mock de dependencias en los tests.
- 
##  Consideraciones generales sobre la solución
- No se usa ningun motor de base de datos. Ni relacional ni noSQL.


Despues de realizar un refactoreo a la solucion monolitica planteada el diseño proporciono esta division de capas:

- APIs
- ApplicationServices
- Domain
- DataAccess

Se busco que cada componente tenga unas pocas responsabilidades, siendo una sola lo ideal.
Por ejemplo el controller UserController en la version inicial hacia desde validaciones de los parametros,
aplicacion de reglas de negocios sobre los  usuarios, lectura de usuarios desde un archivo y controles de duplicacion.
Es decir, el metodo POST principal era responsabled de multitud de intereses.

Luego de la reorganizacion se llego a la cantidad de layers indicadas al principio. Esto brinda ventajas de:
- Cada layer tiene componentes testeables. Pueden mockearse las implementaciones pues se usan contratos en sus dependencias.
- Faciliadad para entender qué hace cada componente.
- Extensibilidad.



Estructura inicial:

![image](https://user-images.githubusercontent.com/2397134/170849054-e8f69a58-d0b5-4e94-859e-9e67b8d062e1.png)

Estructura luego de varias iteraciones de refactoreo:
![image](https://user-images.githubusercontent.com/2397134/170849091-fe9d6f6d-b652-422b-81b8-0bc54cdbfa62.png)


### Extensibilidad
- El patron repository permite implementar modos diferentes de acceder a datos.
- La capa de Application al no depender de la API puede soportar formas diferentes de visualizar/accionar sobre los datos.
- En general las dependencias entre capas son en una sola direccion.
- La capa de dominio se puede decir que es agnostica porque no depende de nada que no sea el propio .net.
