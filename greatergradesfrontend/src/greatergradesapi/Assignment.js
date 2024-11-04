import { useEffect, useState, useContext } from "react";
import { UserContext } from '../functions/UserContext';

const url = 'http://localhost:5000/api/Assignments/'
const getCommonHeader = (token) => ({
  headers: {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  },
});

export const useGetAllAssignments = () => {
  const [assignments, setAssignments] = useState([])
  const { authToken } = useContext(UserContext);
  
  useEffect(() => {
    const fetchAssignment = async () => {
      try {
        const response = await fetch(`${url}`, getCommonHeader(authToken))
        const data = response.json();
        setAssignments(data || [])
      } catch {
        console.error("Error fetching assignments")
      }
    }
    if (authToken) fetchAssignment();
  }, [authToken])
  return assignments;
}


export const useAddAssignment = (name, classId) => {
  const [assignment, setAssignment] = useState({})
  const { authToken } = useContext(UserContext);

  useEffect(() => {
    const fetchAddAssignment = async () => {
      try {
        const response = await fetch(`${url}`, {
          method: 'POST',
          headers: {
            'Authorization': `Bearer ${authToken}`,
            'Content-Type': 'application/json'
            },
          body: JSON.stringify({ name, classId })
        })
        const data = await response.json();
        setAssignment(data || {})
      } catch {
        console.error("Error adding assignment")
      }
    }
    if (authToken, name, classId) fetchAddAssignment();
  }, [authToken, name, classId])
  return assignment;
}


export const useGetAssingmentById = (id) => {
  const [assignment, setAssignment] = useState({})
  const { authToken } = useContext(UserContext);

  useEffect(() => {
    const fetchAssignment = async () => {
      try {
        const response = await fetch(`${url}${id}`, getCommonHeader(authToken))
        const data = await response.json();
        setAssignment(data || {})
      } catch {
        console.error("Error fetching assignment")
      }
    }
    if (authToken && id) fetchAssignment();
  }, [authToken, id])
  return assignment;
}


export const useUpdateAssignment = (id, name, classId) => {
  const { authToken } = useContext(UserContext);

  useEffect(() => {
    const fetchUpdateAssignment = async () => {
      try {
        const response = await fetch(`${url}${id}`, {
          method: 'PUT',
          headers: {
            'Authorization': `Bearer ${authToken}`,
            'Content-Type': 'application/json'
            },
          body: JSON.stringify({ name, classId })
        })
        if (response.status !== 204) throw new Error;
      } catch {
        console.error("Error updating assignment")
      }
    }
    if (authToken && id && name && classId) fetchUpdateAssignment();
  }, [authToken, id, name, classId])
}

export const useDeleteAssignment = (id) => {
  const { authToken } = useContext(UserContext);
  useEffect(() => {
    const fetchDeleteAssignment = async () => {
      try {
        const response = await fetch(`${url}${id}`, {
          method: 'DELETE',
          headers: {
            'Authorization': `Bearer ${authToken}`,
            'Content-Type': 'application/json'
          }
        })
        if (response.status !== 204) throw new Error;
      } catch {
        console.error("Error deleting assignment")
      }
    }
    if (authToken && id) fetchDeleteAssignment();
  }, [authToken, id])
}



//// Fetches not specifially tied to a single endpoint

