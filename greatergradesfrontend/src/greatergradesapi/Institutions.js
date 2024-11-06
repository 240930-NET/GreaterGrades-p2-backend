import { useEffect, useState, useContext } from "react";
import { UserContext } from '../functions/UserContext';

const url = 'http://localhost:5000/api/Institutions/'
const getCommonHeader = (token) => ({
    headers: {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
    },
});


export const useGetAllInstitutions = () => {
    const [institutions, setInstitutions] = useState([])
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchInstitutions = async () => {
            try {
                const response = await fetch(`${url}`, getCommonHeader(authToken));
                const data = await response.json();
                setInstitutions(data || []);
            } catch {
                console.error("Error fetching institutions")
            }
        }
        if (authToken) fetchInstitutions();
    }, [authToken])
    return institutions;
}


export const useAddInstitution = (name) => {
    const [institution, setInstitution] = useState({})
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchAddInstitution = async () => {
            try {
                const response = await fetch(`${url}`, {
                    method: 'POSt',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ name })
                })
                const data = await response.json();
                setInstitution(data || {})
            } catch {
                console.error('Error adding institution')
            }
        }
        if (authToken && name) fetchAddInstitution();
    }, [authToken, name]);
    return institution;
}


export const useGetInstitutionById = (id) => {
    const [institution, setInstitution] = useState({})
    const [loading, setLoading] = useState(true);
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchInstitution = async () => {
            try {
                const response = await fetch(`${url}${id}`, getCommonHeader(authToken));
                const data = await response.json();
                setInstitution(data || {});
            } catch {
                console.error("Error fetching institution")
            } finally {
                setLoading(false);
            }
        }
        if (authToken && id) fetchInstitution();
    }, [authToken, id])
    return {institution, loading};
}


export const useUpdateInstitution = (id, name) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchUpdateInstitution = async () => {
            try {
                const response = await fetch(`${url}${id}`, {
                    method: 'PUT',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ name })
                });
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error updating institution")
            }
        }
        if (authToken && id && name) fetchUpdateInstitution();
    }, [authToken, id, name])
}


export const useDeleteInstitution = (id) => {
    const { authToken } = useContext(UserContext);

    useEffect(() => {
        const fetchDeleteInstitution = async () => {
            try {
                const response = await fetch(`${url}${id}`, {
                    method: 'DELETE',
                    headers: {
                        'Authorization': `Bearer ${authToken}`,
                        'Content-Type': 'application/json'
                    }
                });
                if (response.status !== 204) throw new Error();
            } catch {
                console.error("Error deleting institution")
            }
        }
        if (authToken && id) fetchDeleteInstitution();
    }, [authToken, id])
}


//// non hook functions

export const getInstitutionsAPI = async () => {
    try {
        const response = await fetch(`${url}`);
        const data = await response.json();
        return data || null;
    } catch {
        console.error("Error fetching institutions")
        return null;
    }
}