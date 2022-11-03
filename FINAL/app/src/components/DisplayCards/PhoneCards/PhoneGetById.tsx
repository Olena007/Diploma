import { MDBCard, MDBCardBody, MDBCardImage, MDBCardText, MDBCardTitle, MDBCol, MDBRow } from "mdb-react-ui-kit";
import React, { ReactElement, ReactNode, useContext, useEffect, useState } from "react";
import { Button, Card, Col, ListGroup } from "react-bootstrap";
import { useNavigate, useParams } from "react-router-dom";

interface IPhone {
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

interface IId {
  idPhone: number
}

function GetById (){
    const [phones, setDisplay] = useState<IPhone[]>([]);

    const phoneIdPage = useParams();
    const entries = Object.values(phoneIdPage);

    let num = 0;
    if (entries[0] != undefined){
        num = parseInt(entries[0]);
    }


    const [arrr, setArr ] = useState<Array<any>>([]);

    const Get = async() : Promise<Array<any>>   => {
        console.log("start ");

        const res: Response =  await fetch(`http://localhost:7169/Phone/${num}`);
        const body = await res.json();

        const ent = Object.values(body);


        setArr(ent);


        return arrr;
        
     }
    
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

    useEffect(() => {
        console.log("aaarrs ", arrr);
        Get();

        console.log("aaarr ", arrr);
        console.log("c ", phones);
    }, []);


    
    return(
        <>
        <MDBCard style={{ maxWidth: '1000px' }}>
      <MDBRow className='g-0'>
        <MDBCol md='4'>
          <MDBCardImage src={arrr[3]} alt='...' fluid />
        </MDBCol>
        <MDBCol md='8'>
          <MDBCardBody>
            <MDBCardTitle>{arrr[1]}</MDBCardTitle>
            <MDBCardText>
            {arrr[2]}
            </MDBCardText>
            <MDBCardText>
            {arrr[4]} $
            </MDBCardText>
            <MDBCardText>
              <small className='text-muted'>{arrr[5]}</small>
              <Button onClick={() => createUser(arrr[0])} variant="dark">Add</Button>
            </MDBCardText>
          </MDBCardBody>
        </MDBCol>
      </MDBRow>
    </MDBCard>


         

       
        </>
        
    
    );
      }



export default GetById;