import React from "react";
import { Button, Card, ListGroup } from "react-bootstrap";
import './ComputerCards.css';

interface IComputer{
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

interface IId {
    idPhone: number
}


function Computers (comps : IComputer[], loading : boolean)  {
    function func(a: number) :string{	
        var str = window.location.href = "/computers/" + a;
        return str;
    }

    async function createUser(id : number) {
        try {
          const response = await fetch('http://localhost:7169/BasketComp/' + id, {
            method: 'POST',
            
            headers: {
              'Content-Type': 'application/json',
              Accept: 'application/json',
            },
          });
      
          if (!response.ok) {
            throw new Error(`Error! status: ${response.status}`);
          }
      
          const result = (await response.json()) as IId;
      
          console.log('result is: ', JSON.stringify(result, null, 4));
          alert("added");
      
          return result;
        } catch (error) {
          if (error instanceof Error) {
            console.log('error message: ', error.message);
            return error.message;
          } else {
            console.log('unexpected error: ', error);
            return 'An unexpected error occurred';
          }
        }
      }

    if(loading){
        return <h2>Loading</h2>
    }
    return (
        <div className="items-define">
            <div className="item-define">
                
                {comps.map((comp) => (
                    console.log("id comp", comp.computerId),
                    
                    <Card key={comp.computerId} className="phone-single-item">  
                        <Card.Body>
                            <Card.Img variant="top" src={comp.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{comp.name}</ListGroup.Item>
                            {/* <ListGroup.Item>{comp.description}</ListGroup.Item> */}
                            <ListGroup.Item>{comp.price}</ListGroup.Item>
                        </ListGroup>
                        <Card.Body>
                            <Button onClick={() => createUser(comp.computerId)}>Add</Button>
                            <Button onClick={() => window.open(func(comp.computerId))} variant="dark">More</Button>
                        </Card.Body>
                    </Card> 
                ))}

                
                
            </div> 
        </div>
    );
}



export default Computers;