import React from "react";
import { Button, Card, ListGroup } from "react-bootstrap";

interface IComputer{
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number,
    basketId : number
}

function BasketCompDefine(computers : IComputer[]){
    const deletePhone = async(id: number) => {

        const response = await fetch('http://localhost:7169/BasketComp/' + id, {
                method: 'DELETE',
                headers: {
                'Content-Type': 'application/json',
                Accept: 'application/json',
                },
        });

        if (!response.ok) {
            throw new Error(`Error! status: ${response.status}`);
        }
        console.log('result is: ', response); 
        
        alert("it's just deleted");
        window.location.reload();
    }

    return (
        <div className="items-define">
            <div className="item-define">
                
                {computers.map((comp) => (
                    <Card key={comp.computerId} className="phone-single-item">  
                        <Card.Body>
                            <Card.Img variant="top" src={comp.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{comp.name}</ListGroup.Item>
                            <ListGroup.Item>{comp.price}</ListGroup.Item>
                        </ListGroup>
                        <Card.Body>
                            <Button onClick={() => deletePhone(comp.basketId)} variant="dark">Delete</Button>
                        </Card.Body>
                    </Card> 
                ))}
                
            </div> 
        </div>
    );
}

export default BasketCompDefine;