import { useState } from "react";
import { Client } from "../types/Client.tsx";
import { useClientContext } from "../contexts/ClientContext.tsx";
import FlashMessage from "../components/UIKits/FlashMessage.tsx";
import ClientForm from "../components/Clients/ClientsForm.tsx";
import ClientsTable from "../components/Clients/ClientsTable.tsx";

const ClientsPage: React.FC = () => {
    const [newClient, setNewClient] = useState<Client>({
        personId: 0,
        companyName: '',
        person: {
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        }
    });

    const { addClient } = useClientContext();
    const [flashMessage, setFlashMessage] = useState<boolean>(false);

    const onCloseFlash = () => {
        setFlashMessage(false);
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        addClient(newClient);
        setNewClient({
            personId: 0,
            companyName: '',
            person: {
                firstName: '',
                lastName: '',
                email: '',
                phone: ''
            }
        });
        setFlashMessage(true);
    };

    return (
        <div className="container">
            <div className="flex">
                <h1>Clients</h1>
            </div>
            <ClientForm
                clientData={newClient}
                handleSubmit={handleSubmit}
                setClientData={setNewClient}
            />
            <div className="flex">
                <ClientsTable />
            </div>
            {flashMessage && (
                <FlashMessage
                    title="Client successfully created!"
                    onClose={onCloseFlash}
                    timeout={3000}
                />
            )}
        </div>
    );
};

export default ClientsPage;
