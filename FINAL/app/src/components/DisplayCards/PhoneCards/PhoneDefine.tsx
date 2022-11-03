import axios from "axios";
import { request } from "http";
import React, { MouseEventHandler, SyntheticEvent, useState } from "react";
import { Button, Card, ListGroup } from "react-bootstrap";
import { sortAndDeduplicateDiagnostics } from "typescript";
import './PhoneCards.css';

interface IPnone{
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

interface IId {
    idPhone: number
}

function func(a: number) :string{	
    var str = window.location.href = "/phones/" + a;
    return str;
}

function Phones (phones : IPnone[], loading : boolean)  {
    const [id, setId] = useState(0);
    const [posts, setPosts] = useState([]);

    if(loading){
        return <h2>Loading</h2>
    }

    // const submit = async (e : MouseEventHandler) => {
    //     // e.preventDefault();
        
    //     const responce = await fetch ('http://localhost:7169/Basket/addPhone', {
    //         method: 'POST',
    //         headers: {'Content-Type': 'application/json'},
    //         body: JSON.stringify( {
    //             id,
    //         })
    //     });

    // }

    // function onAdded(idAdded: number){
    //     let posts = [...phones]

    //     const index = posts.findIndex((posts, currentPosts) => {
    //         if (posts.phoneId === idAdded){
    //             return true;
    //         }


    //     });

    //     if (index !== -1){
    //         posts.push(index);
    //     }


    // }

    // async function addPhone (id: number): Promise<IId> {
    //     const requestOptions = {
    //         method: 'POST',
    //         headers: { 'Content-Type': 'application/json' },
    //         body: JSON.stringify({ idPhone: id })
    //       };
    //       const response = await fetch('http://localhost:7169/Basket/addPhone', requestOptions);
    //       console.log("response ", response.json());
    //       console.log("okki ", response);
    //       return await response.json();

          

        //const url = `http://localhost:7169/Basket/addPhone`

        // const data = {
        //     id : id
        // }

        // const responce = fetch(url, {
        //     method: 'POST',
        //     headers: {'Content-Type': 'application/json'},
        //     credentials: 'include',
        //     body: JSON.stringify( {id})
        // })
        // .catch((error) => {
        //     console.log(error);
        // });

        // .then((result) => {
        //     if(result.data.statusCode === '200'){
        //         alert('item added');
        //     }
        //     else{
        //         alert('no item added');
        //     }
        // })
        // .catch((error) => {
        //     console.log(error);
        // });

        // axios.post(url, data)
        // .then((result) => {
        //     if(result.data.statusCode === '200'){
        //         alert('item added');
        //     }
        //     else{
        //         alert('no item added');
        //     }
        // })
        // .catch((error) => {
        //     console.log(error);
        // })
       
    //}

    // const addPhone = async(id: number) => {
    //     const url = `https://cors-anywhere.herokuapp.com/http://localhost:7169/Basket/addPhone`

    //     const {responce} = await fetch (url, {
    //         method: 'POST',
    //         headers: {'Content-Type': 'application/json'},
    //         body: JSON.stringify( {
    //             id
    //         })
    //     });

    //     console.log(responce);
    //     alert("added");
    //     // fetch(url, {
    //     //     method: 'POST'
    //     // })
    //     // .then(response => response.json())
    //     // .then(responseFromServer => {
    //     //     console.log(responseFromServer);
    //     //     //onAdded(id);
    //     // })
    //     // .catch((error) => {
    //     //     console.log(error);
    //     //     alert(error);
    //     // });
    // }

    // const adddd = async(index : number) : Promise<IId> => {
    //     const requestOptions = {
    //       method: 'POST',
    //       headers: { 'Content-Type': 'application/json' },
    //       body: JSON.stringify({ id: index  })
    //     };
    //     console.log(request);
    //     const response = await fetch('http://localhost:7169/Basket/addPhone', requestOptions);
    //     return response.json();
    //   }

    async function createUser(id : number) {
        try {
          const response = await fetch('http://localhost:7169/Basket/' + id, {
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

    


    return (
        <div className="items-define">
            <div className="item-define">
                
                {phones.map((phone) => (
                    <Card key={phone.phoneId} className="phone-single-item" >  
                        <Card.Body>
                            <Card.Img variant="top" src={phone.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{phone.name}</ListGroup.Item>
                            {/* <ListGroup.Item>{phone.description}</ListGroup.Item> */}
                            <ListGroup.Item>{phone.price}</ListGroup.Item>
                        </ListGroup>
                        <Card.Body>
                            <Button onClick={() => createUser(phone.phoneId)}>Add</Button>
                            <Button onClick={() => window.open(func(phone.phoneId))} variant="dark">More</Button>
                        </Card.Body>
                    </Card> 
                ))}
                
            </div> 
        </div>
    );
}



export default Phones;