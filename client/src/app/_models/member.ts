import { Photo } from "./Photo";

export interface Member {
  id: number
  userName: string
  photoUrl: string
  age: number
  knownAs: string
  created: Date
  lastActive: Date
  gender: string
  interests: string
  city: string
  country: string
  photos: Photo[]
}


