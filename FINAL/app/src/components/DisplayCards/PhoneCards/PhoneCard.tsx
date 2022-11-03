import React, { useEffect, useState } from "react";
import { Dropdown } from "react-bootstrap";
import { useSearchParams } from "react-router-dom";

import Phones from './PhoneDefine';
import Sort from './Sorting';

interface IPnone{
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

function PhoneCard () {
    const [phones, setDisplay] = useState<IPnone[]>([]);
    const [phonesName, setDisplayName] = useState<IPnone[]>([]);
    const [phonesDesc, setDisplayDesc] = useState<IPnone[]>([]);
    const [phonesAsce, setDisplayAsce] = useState<IPnone[]>([]);
    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrent] = useState(1);
    const [phonesPerPage] = useState(5);
    const [search, setSearch] = useSearchParams();

    useEffect(() => {
        const fetchGetAll = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Phone')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplay(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetAll();
         

    }, []);

    useEffect(() => {
        const fetchGetName = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Phone/byName')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayName(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetName();
         

    }, []);

    useEffect(() => {
        const fetchGetDesc = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Phone/priseDesc')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayDesc(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetDesc();
    }, []);

    useEffect(() => {
        const fetchGetAsce = async () => {
            setLoading(true);

        fetch('http://localhost:7169/Phone/priseAsce')
            .then(response => response.json())
            .then(added => {
                console.log(added);
                setDisplayAsce(added);
            })
            .catch((error) => {
                console.log(error);
            });

        setLoading(false);
        }

        fetchGetAsce();
    }, []);

    console.log("phones");
    console.log("phones cuka ", phones);
    console.log("length");
    console.log(phones.length);

    const indexOfLastPhone = currentPage * phonesPerPage;
    const indexOfFirstPhone = indexOfLastPhone - phonesPerPage;
    const currentPhone = phones.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneName = phonesName.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneDesc = phonesDesc.slice(indexOfFirstPhone, indexOfLastPhone);
    const currentPhoneAsce = phonesAsce.slice(indexOfFirstPhone, indexOfLastPhone);

    console.log("CURRENTTTT ", currentPhone);

    const paginate = (pageNumber : number) => setCurrent(pageNumber);

    function pag (pageNumber : number){
        setCurrent(pageNumber);
    }

    function Pagination (postPerPage : number, totalPost : number){
        const pageNumbers = [];
    
    
        for(let i = 1; i <= Math.ceil(totalPost / postPerPage); i++){
            pageNumbers.push(i);
        }
    
        return(
            <nav>
                <ul className="pagination">
                    {pageNumbers.map(number => (
                        <li key={number} className="page-item">
                            <a onClick={() => pag(number)} className="page-link">{number}</a>
                        </li>
                    ))}
                </ul>
            </nav>
        );
    }

    
    

    let url = window.location.href;
    let menu;
    if (url === "http://localhost:3000/phones?set=name" ) {
        menu = (
            <>{Phones(currentPhoneName, loading)}</>
        )
    }
    else 
    if (url === "http://localhost:3000/phones"){
        menu = (
            <>{Phones(currentPhone, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/phones?set=suggested"){
        menu = (
            <>{Phones(currentPhone, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/phones?set=priceDesc"){
        menu = (
            <>{Phones(currentPhoneDesc, loading)}</>
        ) 
    }
    else
    if (url === "http://localhost:3000/phones?set=priceAsc"){
        menu = (
            <>{Phones(currentPhoneAsce, loading)}</>
        ) 
    }
    
    return(
        <div className="phone-list">
            <h1>List Phones</h1>
            <Sort options={[
            {
                label: 'Suggested',
                value: 'suggested',
            },
            {
              label: 'Name',
              value: 'name',
            },
            {
              label: 'Price From High To Low',
              value: 'priceDesc',
            },
            {
              label: 'Price From Low To High',
              value: 'priceAsc',
            },
          ]} label = {"Sort by"} name={"sort"} defaultValue={''} onChange={(e) => {search.set('set', e.target.value);
          setSearch(search, {replace: true})}}

           />
            {menu}
            {Pagination(phonesPerPage, phones.length)}
        </div>
    );
    
}
export default PhoneCard;