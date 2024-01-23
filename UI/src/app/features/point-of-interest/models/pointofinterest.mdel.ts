export interface PointOfInterest {
    id: number,
    name: string,
    description: string,
    cityName: string,
    userId: number

}
export interface PointOfInterestEdit {
    id: number,
    name: string,
    description: string,
    cityId: number,
    userId: number

}
export interface cityid{
    cityId: number
}

export interface PointOfInterestShow {
    id: number,
    name: string,
    description: string,
    cityId: number,

}