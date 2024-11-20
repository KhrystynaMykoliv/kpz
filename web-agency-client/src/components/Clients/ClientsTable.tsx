import React, { useState } from "react";
import { Client } from "../../types/Client";
import { useClientContext } from "../../contexts/ClientContext";
import Button from "../UIKits/Button";
import ModalWindow from "../UIKits/ModalWindow";

const ClientsTable: React.FC = () => {
    const { clients, deleteClient } = useClientContext();
    const [deleteWindow, setDeleteWindow] = useState<boolean>(false);
    const [selectedClient, setSelectedClient] = useState<Client | null>(null);

    const openDeleteWindow = (client: Client) => {
        setSelectedClient(client);
        setDeleteWindow(true);
    };

    const closeDeleteWindow = () => {
        setDeleteWindow(false);
        setSelectedClient(null);
    };

    const confirmDelete = () => {
        if (selectedClient) {
            deleteClient(selectedClient.personId);
            closeDeleteWindow();
        }
    };

    return (
        <div>
            <table>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Company Name</th>
                    <th>Full Name</th>
                    <th>Email</th>
                    <th>Phone Number</th>
                    <th className="actions">Actions</th>
                </tr>
                </thead>
                <tbody>
                {clients.map((client) => (
                    <tr key={client.personId}>
                        <td>{client.personId}</td>
                        <td>{client.companyName}</td>
                        <td>
                            {client.person
                                ? `${client.person.firstName} ${client.person.lastName}`
                                : "N/A"
                            }
                        </td>
                        <td>{client.person?.email || "N/A"}</td>
                        <td>{client.person?.phone || "N/A"}</td>
                        <td className="actions">
                            <Button
                                text="Edit"
                                color="gray"
                                link={true}
                                to={`/clients/edit/${client.personId}`}
                            />
                            <Button
                                text="Delete"
                                color="red"
                                onClick={() => openDeleteWindow(client)}
                            />
                        </td>
                    </tr>
                ))}
                </tbody>
            </table>
            {deleteWindow && (
                <ModalWindow
                    opened={deleteWindow}
                    onClose={closeDeleteWindow}
                    title="Are you sure?"
                    onSubmit={confirmDelete}
                >
                    <p>Client data will be permanently deleted!</p>
                </ModalWindow>
            )}
        </div>
    );
};

export default ClientsTable;
