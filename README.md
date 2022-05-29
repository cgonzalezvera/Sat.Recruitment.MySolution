# SAT Recruitment

### Autor: Claudio González Vera

## Lenguaje de programación y frameworks usados
- La plataforma en que se desarrollo es netcore 3.1
- Moq para hacer mock de dependencias en los tests.

##  Consideraciones generales sobre la solución
- No se usa ningun motor de base de datos. Ni relacional ni noSQL.


Despues de realizar un refactoreo a la solucion monolitica planteada el diseño proporciono esta division de capas:

- APIs
- ApplicationServices
- Domain
- DataAccess

Se busco que cada componente tenga unas pocas responsabilidades, siendo una sola lo ideal.
Por ejemplo el controller UserController en la version inicial hacia desde validaciones de los parametros,
aplicacion de reglas de negocios sobre los  usuarios, lectura desde un archivo hasta controles de duplicacion.
Es decir, el metodo POST principal tuvo responsabilidades multiples: antes necesidades de cambios muchos impactaban en el mismo componente.

Luego de la reorganizacion se llego a la cantidad de layers indicadas al principio. Esto brinda ventajas de:
- Cada layer tiene componentes testeables. Pueden mockearse las implementaciones pues se usan contratos en sus dependencias.
- Faciliadad para entender qué hace cada componente.
- Extensibilidad.



Estructura inicial:

![image](https://user-images.githubusercontent.com/2397134/170849054-e8f69a58-d0b5-4e94-859e-9e67b8d062e1.png)

Estructura luego de varias iteraciones de refactoreo:
![image](https://user-images.githubusercontent.com/2397134/170849091-fe9d6f6d-b652-422b-81b8-0bc54cdbfa62.png)


### Cómo los principios SOLID fueron usandos:
- (S) Por el ejemplo el caso mencionado del UsuarioController asi como otras clases [tal como la que solo se dedica a traer datos desde un archivo](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.DataAccess/Implementation/UsersStreamReder.cs).
- (O) El patron builder que se empleo a traves de la clase [UserBaseBuilder](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.Domain/Services/UserBuilder/UserBaseBuilder.cs) puede considerarse una aplicacion del Open-Closed princpile
- (L) El patron repository permite [implementar modos diferentes de acceder a los datos](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.Domain/Contracts/IUserRepository.cs). Y en general el hecho de que las implementaciones de contratos a su vez dependan de abstracciones hacen uso del principio Liskov.
- (I) El principio de segregacion de interfaces se ve ejecutado en que los contratos son pequeños y no demarcan multitud de signaturas. Por jemplo [IUserTextLineValidator](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.DataAccess/Contracts/IUserTextLineValidator.cs) o [IEmailNormalize](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.Domain/Services/Contracts/IEmailNormalize.cs).
- (D) El principio de Dependency Injection en la mayoria de las clases, pues sus dependencias se hacen contra contratos y no contra implementaciones especificas. Ejemplo UserController o [UserService](https://github.com/cgonzalezvera/Sat.Recruitment.MySolution/blob/58bdfed87daa1446f8d2d262627d0ba0247b663b/Sat.Recruitment.ApplicationServices/UserService.cs)

### Generales
- La capa de Application al no depender de la API puede soportar formas diferentes de visualizar/accionar sobre los datos.
- En general las dependencias entre capas son en una sola direccion.
- La capa de dominio se puede decir que es agnostica porque no depende de nada que no sea el propio .net.
