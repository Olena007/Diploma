import axios from "axios";
import React, { useEffect, useState } from "react";
import { Button, Card, ListGroup } from "react-bootstrap";
import BasketComputer from './BasketCompDefine';
import { Link } from "react-router-dom";

import BasketSingle from "./BasketDefine";

interface IBasket {
    basketId: number,
    phoneId : number,
    clientId: number
}

interface IBasketComp {
    basketId: number,
    computerId : number,
    clientId: number
}

interface IPhone {
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

interface ID {
    phoneId: number,
}

interface IId {
    idPhone: number
}

interface IComputer{
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number,
    basketId : number
}

const Basket = (props : {name: string}) => {
    const [basket, setDisplay] = useState<IBasket[]>([]);
    const [phones, setPhones] = useState<IPhone[]>([]);
    const [name, setName] = useState('');
    const [arrB, setArrB ] = useState<Array<any>>([]);
    const [basketComp, setDisplayComp] = useState<IBasketComp[]>([]);
    const [computers, setComps] = useState<IComputer[]>([]);

    


    useEffect(() => {
        const fetchClient = async () => {
            const responce = await fetch ('http://localhost:7169/api/client', {
            method: 'GET',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include'
        });

        const body = await responce.json();
            //console.log("body ", body);
                const ent = body.email;
               // console.log("email ", ent);

                setName(ent);



            //const element = document.querySelector('#get-request-async-await .result');
            //const response = await axios.get('http://localhost:7169/api/client', { withCredentials: true });
            //element.innerHTML = response.data.total;
            //const body = await response.json();

            
            // const res: Response =  await fetch(`http://localhost:7169/api/client`);
            //     const body = await res.json();
            //     console.log("body ", body);



            //     const ent = body.email;
            //     console.log("email ", ent);

            //     setName(ent);

            // fetch('http://localhost:7169/api/client')
            // .then(response => response.json())
            // .then(added => {
            //     setName(added);
            // })
            // .catch((error) => {
            //     console.log(error);
            // });
        }

        fetchClient();
    }, []);

    //console.log("name ", name);

    useEffect(() => {
        const fetchGetAll = async () => {

        fetch('http://localhost:7169/Basket')
            .then(response => response.json())
            .then(added => {
                setDisplay(added);
            })
            .catch((error) => {
                console.log(error);
            });
        }
        fetchGetAll();
    }, []);


    useEffect(() => {
        const fetchGetAllComp = async () => {

        fetch('http://localhost:7169/BasketComp')
            .then(response => response.json())
            .then(added => {
                setDisplayComp(added);
            })
            .catch((error) => {
                console.log(error);
            });
        }
        fetchGetAllComp();
    }, []);

   // console.log("test ", basketComp);

    var arrnum : Array<any> = [];
    var arrnumComp : Array<any> = [];

    for(let i = 0; i < basket.length; i++){
        arrnum[i] = basket[i].basketId;
    }

    for(let i = 0; i < basketComp.length; i++){
        arrnumComp[i] = basketComp[i].basketId;
    }

    

    //console.log("console log ", arrnum);

    function createHistory(i: number) {
        try {
            
            console.log("ok im here ");
                const response =  fetch('http://localhost:7169/History/' + arrnum[i], {
                method: 'POST',
                headers: {
                'Content-Type': 'application/json'
                },
                });
      
                //console.log("arrnum ", arrnum);
                // if (!response.ok) {
                //     throw new Error(`Error! status: ${response.status}`);
                // }
      
                console.log("response", response);
                // const result = (await response.json()) as IId;
      
                //console.log('result is: ', JSON.stringify(result, null, 4));
              
            //alert("added");
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

       function deleteBasket(id : number){
        const responce = fetch ('http://localhost:7169/Basket/' + arrnum[id], {
            method: 'DELETE',
            headers: {'Content-Type': 'application/json'},
            
        });

        //alert("deleted");
    }

    function createHistoryComp(i: number) {
        try {
            

                const response = fetch('http://localhost:7169/History/Comp/' + arrnumComp[i], {
                method: 'POST',
                headers: {
                'Content-Type': 'application/json',
                Accept: 'application/json',
                },
                });
      
                //console.log("arrnum ", arrnum);
                // if (!response.ok) {
                //     throw new Error(`Error! status: ${response.status}`);
                // }
      
                // const result = (await response.json()) as IId;
      
                //console.log('result is: ', JSON.stringify(result, null, 4));
              
            //alert("added");
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

    function deleteBasketComp(id : number){
        const responce = fetch ('http://localhost:7169/BasketComp/' + arrnumComp[id], {
            method: 'DELETE',
            headers: {'Content-Type': 'application/json'},
            
        });

        //alert("deleted");
    }

    var array : Array<any> = [];
    var arrayComp : Array<any> = [];

    var arrtry: Array<any> = [];
    var arrnext: Array<any> = [];


    useEffect(() => {
        setPhones(arrtry);
    },[])


    useEffect(() => {
        const GetPhone = async() : Promise<Array<any>>   => {
            for (let i = 0; i < basket.length; i ++){

                const res: Response =  await fetch(`http://localhost:7169/Phone/${basket[i].phoneId}`);
                const body = await res.json();

    
                const ent = Object.values(body);
                //console.log("id for del 2 ", ent);

                arrtry.push(body);
                arrnext.push(body);

                array.push(ent);

                setArrB(array);
                
            } 
            setPhones(arrtry);
            return arrtry;
         }
         
        GetPhone();
    },[basket.length + 1]);

    useEffect(() => {
        const GetComp = async() : Promise<Array<any>>   => {
            for (let i = 0; i < basketComp.length; i ++){

                const res: Response =  await fetch(`http://localhost:7169/Computer/${basketComp[i].computerId}`);
                const body = await res.json();

                arrayComp.push(body);

                //setArrB(array);
                
            } 
            setComps(arrayComp);
            return array;
         }
         
        GetComp();
    },[basketComp.length + 1]);

    //console.log("test 2 ", computers);



    let conct: Array<any> = [];
    let conct2: Array<any> = [];

   conct2 = phones;

    for(let i = 0; i < basket.length; i++){
        conct[i] = basket[i].basketId;
    }

    for(let i = 0; i < conct2.length; i++){
        conct2[i].basketId = conct[i];
    }


    let conctC: Array<any> = [];
    let conct2C: Array<any> = [];

   conct2C = computers;

    for(let i = 0; i < basketComp.length; i++){
        conctC[i] = basketComp[i].basketId;
    }

    for(let i = 0; i < conct2C.length; i++){
        conct2C[i].basketId = conctC[i];
    }

    //console.log("test 3 ", conct2C);

   // console.log("arrnum ", arrnum);

    function funcPost(){
        let counter = 0;

        if (counter == 0){
            for(let i = 0; i < arrnum.length; i++){
            createHistory(i);
            //deleteBasket(i);
        }
        counter ++;
        }

        // if (counter == 1){
        //     for(let i = 0; i < arrnum.length; i++){
        //     createHistory(i);
        //     //deleteBasket(i);
        // }
        // }
        

        

        for(let i = 0; i < arrnumComp.length; i++){
            createHistoryComp(i);
            //deleteBasketComp(i);
        }

        //conct2 = [];
        alert("Thank for shopping!");

    }
    
    // console.log("cnct  ", conct);
    // console.log("cnct2  ", conct2);

    let menu;
    let price = 0;
    let price2 =0;
    let total = 0;

    function totalprice() : number{
        const summ = phones.map(x => x.price);
        const summ2 = computers.map(x => x.price);
        
        for(let i = 0; i < summ.length; i++){
            price = price + summ[0];
        }


        for(let i = 0; i < summ2.length; i++){
            price2 = price2 + summ2[0];
        }

        total = price + price2;
        return total;
    }

    
    totalprice();
    // console.log("price ", price);

    if (props.name == null ) {
        menu = (
            <div>
                <div>You are not logged in -- Please Sign in</div>
                <Button href="/login" variant="success">Go to sign</Button>


            </div>
        )

    } 
    else
    if (props.name === name)
    {
        menu = (
            <>
            {BasketSingle(conct2)}
            {BasketComputer(conct2C)}
            <h2>Total price: {total}</h2>
            <Button onClick={() => funcPost()} variant="success">Buy</Button>
            <Button href="/history" variant="dark">History</Button>
            </>
        )
    }

    return(
        <div>
            <h1>Basket</h1>
            {menu} 
            
        </div>
    );
} 

export default Basket;