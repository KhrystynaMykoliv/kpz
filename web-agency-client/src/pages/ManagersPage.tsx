import React, { useState } from "react";
import { Manager } from "../types/Manager.tsx";
import { useManagerContext } from "../contexts/ManagerContext.tsx";
import FlashMessage from "../components/UIKits/FlashMessage.tsx";
import ManagersForm from "../components/Managers/ManagersForm.tsx";
import ManagersTable from "../components/Managers/ManagersTable.tsx";

const ManagersPage: React.FC = () => {
    const [newManager, setNewManager] = useState<Manager>({
        personId: 0,
        startedWork: new Date(),
        person: {
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        }
    });

    const { addManager } = useManagerContext();
    const [flashMessage, setFlashMessage] = useState<boolean>(false);

    const onCloseFlash = () => {
        setFlashMessage(false);
    };

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        addManager(newManager);
        setNewManager({
            personId: 0,
            startedWork: new Date(),
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
                <h1>Managers</h1>
            </div>
            <ManagersForm
                managerData={newManager}
                handleSubmit={handleSubmit}
                setManagerData={setNewManager}
            />
            <div className="flex">
                <ManagersTable />
            </div>
            {flashMessage && (
                <FlashMessage
                    title="Manager successfully created!"
                    onClose={onCloseFlash}
                    timeout={3000}
                />
            )}
        </div>
    );
};

export default ManagersPage;
