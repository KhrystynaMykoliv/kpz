import React, { useState } from "react";
import { Manager } from "../../types/Manager";
import { useManagerContext } from "../../contexts/ManagerContext";
import Button from "../UIKits/Button";
import ModalWindow from "../UIKits/ModalWindow";

const ManagersTable: React.FC = () => {
    const { managers, deleteManager } = useManagerContext();
    const [deleteWindow, setDeleteWindow] = useState<boolean>(false);
    const [selectedManager, setSelectedManager] = useState<Manager | null>(null);

    const openDeleteWindow = (manager: Manager) => {
        setSelectedManager(manager);
        setDeleteWindow(true);
    };

    const closeDeleteWindow = () => {
        setDeleteWindow(false);
        setSelectedManager(null);
    };

    const confirmDelete = () => {
        if (selectedManager) {
            deleteManager(selectedManager.personId);
            closeDeleteWindow();
        }
    };

    return (
        <div>
            <table>
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Full Name</th>
                    <th>Email</th>
                    <th>Phone Number</th>
                    <th>Started Work</th>
                    <th className="actions">Actions</th>
                </tr>
                </thead>
                <tbody>
                {managers.map((manager) => (
                    <tr key={manager.personId}>
                        <td>{manager.personId}</td>
                        <td>
                            {manager.person
                                ? `${manager.person.firstName} ${manager.person.lastName}`
                                : "N/A"
                            }
                        </td>
                        <td>{manager.person?.email || "N/A"}</td>
                        <td>{manager.person?.phone || "N/A"}</td>
                        <td>{manager.startedWork ? new Date(manager.startedWork).toLocaleDateString() : "N/A"}</td>
                        <td className="actions">
                            <Button
                                text="Edit"
                                color="gray"
                                link={true}
                                to={`/managers/edit/${manager.personId}`}
                            />
                            <Button
                                text="Delete"
                                color="red"
                                onClick={() => openDeleteWindow(manager)}
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
                    <p>Manager data will be permanently deleted!</p>
                </ModalWindow>
            )}
        </div>
    );
};

export default ManagersTable;
