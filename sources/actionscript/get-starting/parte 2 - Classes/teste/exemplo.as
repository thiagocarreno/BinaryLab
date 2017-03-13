package teste
{
import flash.events.Event;
import mx.containers.Panel;
import mx.controls.Label;
import mx.events.ChildExistenceChangedEvent;
import mx.events.FlexEvent;
public class teste extends Panel
{
//colocamos a imagem como embed (incoporada no nosso aplicativo e definida
//com a variavel imediatamente em baixo (iconImg) disponível na forma de class.
[Embed("flexBtn.png")]
private var iconImg:Class;
/*Esta propriedade estará disponivel como elitura/escrita por exemplo: meuPainel.nomePessoal */
[Bindable]
private var _nomePessoal:String;
//Disponivel como dataCriacao em modo de leitura apenas; meuPainel.dataCriacao
private var _dataCriacao:String;
//variavel temporaria usada para saber as horas/minutos/segundos usados em baixo
private var dados:Date = new Date;
public function teste()
{
//definimos o painel
this.width=270;
this.height=270;
this.x=0;
this.y=0;
//adicionamos o eventListner
this.addEventListener(FlexEvent.CREATION_COMPLETE, criado,false,0,true);
}
private function criado(evt:FlexEvent):void {
/*definimos a hora exacta da criação do painel, com recurso ao date, neste caso d variável dados */
_dataCriacao=dados.getHours()+":"+dados.getMinutes()+":"+dados.getSeconds();
//adicionamos o icon ao painel
this.titleIcon=iconImg;
//verificamos se o nomePessoal foi definido
if(!_nomePessoal) {
/*se o nome nao tiver sido dados, damos um nome temporário, no caso será dados como:
Teste Painel "numero" onde o numero será um valor aleatório entre 0 e 15, este
numero é conseguido através do Math.floor(Math.ramdom()*15); */
_nomePessoal="Teste Painel "+Math.floor(Math.random()*15);
}
/*vamos usar um label que indica o nomePessoal e a hora da criação do painel, este
Label desaparecerá assim que forem adicionados filhos ao painel, para isso usamos um
evenListner
*/
var lbl:Label = new Label;
lbl.name="status";
lbl.x=0;
lbl.y=0;
//definimos o texto
lbl.text=_nomePessoal + " criado em: "+dataCriacao;
//adicionamos como child ao painel
this.addChild(lbl);
//event listner para sabermos quando foi adicionado um filho ao painel para
//podermos remover o label colocado em cima.
this.addEventListener(ChildExistenceChangedEvent.CHILD_ADD, remove, false, 0, true);
//despacha o evento terminado personalizado
this.dispatchEvent(new Event("btnsProntos"));
//remove o eventListner terminao, visto que apenas será disparado uma vez.
this.removeEventListener(FlexEvent.CREATION_COMPLETE, criado);
}
private function remove(evt:ChildExistenceChangedEvent):void {
//função para remover o label com o nome e hora de criação, isto acontece quando é adicionado
//um filho ao painel.
//removemos o child 0 (é o child lbl usado em cima, é o numero zero porque nada mais foi adicionado
ao painel)
this.removeChildAt(0);
//removemos o event listner caso contrario se forem adicionados mais que um filho
//esta função vai remover sempre o ultimo inserido
this.removeEventListener(ChildExistenceChangedEvent.CHILD_ADD, remove);
}
/*como quero apenas que a propriedade de dataCriacao seja apenas de leitura, fazemos
apenas a função para ler esse valor, com o get, chamado getter */
public function get dataCriacao():String {
return _dataCriacao;
}
/*como quero que a propriedade _nomePessoal seja quer de leitura, quer de escrita, tenho que
dizer à nossa classe que pode disponibilizar ou receber conteúdo de/nessa variável, fazendo isso com
as funções get e set **/
public function get nomePessoal():String {
return _nomePessoal;
}
//Recebe uma string como nome
public function set nomePessoal(nome:String):void {
_nomePessoal=nome;
}
}
}