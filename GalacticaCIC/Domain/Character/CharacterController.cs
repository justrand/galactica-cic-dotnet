using GalacticaCIC.Json;

namespace GalacticaCIC.Domain.Character;

public class CharacterController: Controller
{
    private DataContext _dataContext;
    
    public CharacterController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public ActionResult GetCharacters()
    {
        return Ok();
    }

    [HttpPost("migratedata")]
    public async Task<ActionResult> MigrateData([FromBody] List<CharacterJson> characterJson)
    {
        return Ok();
    }
}
