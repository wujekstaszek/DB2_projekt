CREATE DATABASE clob;
USE clob;


 create fulltext catalog FullTextCatalog as default

 select *
 from sys.fulltext_catalogs


CREATE TABLE testowa1(
id int IDENTITY(1, 1) PRIMARY KEY,
nazwa varchar(1000),
tresc varchar(max),
);




declare @id varchar(100);
select @id=name from sysindexes where object_id('testowa1') = id;
declare @state varchar(200);
set @state='create fulltext index on testowa1(tresc)
 key index '+CAST(@id AS varchar)+';';
 EXEC (@state);




 INSERT INTO testowa1 VALUES ('Lorem Ipsum','Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi venenatis pretium vehicula. Pellentesque at ornare risus. Duis erat nulla, ultrices vitae rutrum eu, posuere fermentum velit. Donec in magna porttitor, porttitor elit sed, auctor ante. Nullam ac justo ut sapien commodo pharetra. Duis nec ante consectetur, semper nisi suscipit, consectetur felis. Nullam dignissim finibus commodo. Cras id euismod ex.

Integer mollis pellentesque enim, eget pellentesque urna hendrerit eu. Pellentesque rhoncus felis ipsum, quis gravida urna dapibus a. Pellentesque quis turpis ullamcorper, mollis turpis at, consequat elit. Praesent semper et quam nec pulvinar. Maecenas leo ante, porta eget risus at, consectetur maximus nibh. Praesent tristique, metus sit amet commodo tempus, ex dolor tristique dui, porttitor lacinia mauris quam quis turpis. Aliquam erat volutpat. Integer vehicula commodo augue, non dictum massa finibus scelerisque. Fusce et luctus purus.

Nam in iaculis velit. Nunc a fermentum purus. Ut pharetra diam vel augue iaculis pharetra. Aenean ut est ullamcorper, interdum neque ac, auctor lacus. Suspendisse erat magna, malesuada non dapibus at, pellentesque at nunc. Donec sagittis orci quis ultricies placerat. Pellentesque pretium urna ut nisi venenatis auctor. Fusce tempus lacus lorem, vel porta lorem bibendum eget.

Etiam mollis elit id arcu facilisis, sed tristique lorem mattis. In vitae orci nec augue finibus faucibus. Nulla egestas velit nec egestas porta. Aliquam quis maximus tortor. Etiam vitae mauris commodo, pretium est in, ultricies nibh. Curabitur egestas lacinia sem nec interdum. Nulla quis bibendum turpis. Etiam eleifend eget metus a tempus. Quisque id tristique turpis, et lacinia sem. Cras et massa nulla. Praesent aliquet felis neque, at imperdiet ante pharetra ut. Curabitur euismod mauris et felis mattis, a congue nunc malesuada. Praesent eu ligula vel tortor viverra sodales a id lacus. Donec eget lacus in leo scelerisque posuere. Cras eu orci elit.

Maecenas auctor dolor a arcu convallis ultricies. Praesent sodales velit a tellus dictum aliquam. Donec vel dapibus odio. Phasellus ac sodales augue. Sed sit amet urna sed nibh mattis bibendum. Morbi rhoncus est vitae ex dictum, a faucibus nunc rhoncus. Fusce lobortis, tellus bibendum aliquam tincidunt, dolor ligula imperdiet nunc, et dapibus est tellus ac diam. Vestibulum nibh lacus, tempus nec dictum eu, tristique sed elit. Cras aliquam maximus felis id pellentesque. In hac habitasse platea dictumst. Vivamus fringilla ac nulla id interdum. Nunc nibh nulla, mollis nec nisi tempus, euismod maximus augue. Quisque in ipsum nec sem laoreet tempus sed ac odio.');

 INSERT INTO testowa1 VALUES ('TestowyDokument1','TestowyCiag1');
 INSERT INTO testowa1 VALUES ('TestowyDokument2','TestowyCiag2');
 INSERT INTO testowa1 VALUES ('TestowyDokument3','TestowyCiag3');
 INSERT INTO testowa1 VALUES ('TestowyDokument4','TestowyCiag4');