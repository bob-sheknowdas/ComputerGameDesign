#pragma strict

public var Layer_1:Transform;
public var Layer_2:Transform;
public var Layer_3:Transform;
public var Layer_4:Transform;


function Start () {

}

function Update () {
	
	
	transform.position.x +=Input.GetAxis("Horizontal")*.08;
		
	Layer_1.transform.position.x = transform.position.x*-0.2;
	Layer_3.transform.position.x = transform.position.x*.5;
	Layer_4.transform.position.x = transform.position.x*.8;
}
