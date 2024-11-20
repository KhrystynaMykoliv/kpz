import React, { useEffect, useState } from "react";
import { useClientContext } from "../contexts/ClientContext.tsx";
import { useNavigate, useParams } from "react-router-dom";
import { Client } from "../types/Client.tsx";
import ClientsForm from "../components/Clients/ClientsForm.tsx";

const EditClientsPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const { clients, updateClient } = useClientContext();
    const navigate = useNavigate();

    const clientToEdit = clients.find(client => client.personId === Number(id));

    const [clientData, setClientData] = useState<Client>({
        personId: 0,
        companyName: '',
        person: {
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        }
    });

    useEffect(() => {
        if (clientToEdit) {
            setClientData(clientToEdit);
        }
    }, [clientToEdit]);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (clientData) {
            updateClient(clientData.personId, clientData);
            navigate("/");
        }
    };

    if (!clientData) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Edit Client</h1>
            <ClientsForm
                clientData={clientData}
                setClientData={setClientData}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default EditClientsPage;
