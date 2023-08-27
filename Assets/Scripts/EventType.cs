public enum EventType
{
    OnInteract, // на взаимодействие с объектом
    OnInteractObjectEnter, // на вхождение в зону объекта для взаимодействия
    OnInteractObjectExit, // вышел из зоны взаимодействия
    OnInteractObjectStay, // Пока стоишь в зоне взаимодействия
    OnPickItem, // подбор предмета в инвентарь
    OnRemoveItemFromInventory, // при использовании либо при выбрасывании
    OnInteractLamper,
    OnEndFillWindows, // когда менеджер закончит заливать окна краской
    OnStartFillWindows, // когда менеджер начнет заливать окна краской
    OnCompleteLevel
}
