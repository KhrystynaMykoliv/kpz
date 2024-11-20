import React, { useEffect, useState } from "react";
import { useManagerContext } from "../contexts/ManagerContext.tsx";
import { useNavigate, useParams } from "react-router-dom";
import { Manager } from "../types/Manager.tsx";
import ManagersForm from "../components/Managers/ManagersForm.tsx";

const EditManagersPage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const { managers, updateManager } = useManagerContext();
    const navigate = useNavigate();

    const managerToEdit = managers.find(manager => manager.personId === Number(id));

    const [managerData, setManagerData] = useState<Manager>({
        personId: 0,
        startedWork: new Date(),
        person: {
            firstName: '',
            lastName: '',
            email: '',
            phone: ''
        }
    });

    useEffect(() => {
        if (managerToEdit) {
            setManagerData(managerToEdit);
        }
    }, [managerToEdit]);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (managerData) {
            updateManager(managerData.personId, managerData);
            navigate("/managers");
        }
    };

    if (!managerData) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h1>Edit Manager</h1>
            <ManagersForm
                managerData={managerData}
                setManagerData={setManagerData}
                handleSubmit={handleSubmit}
            />
        </div>
    );
};

export default EditManagersPage;
